(function ($) {
    var self = this;
    self.Data = [];
    self.IsUpdate = false;
    self.RoleId = "";
    self.RenderTableHtml = function (data) {
        var html = "";
        var index = 0;
        if (data != "" && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                html += "<tr>";
                var item = data[i];
                html += "<td>" + (++index) + "</td>";
                html += "<td>" + item.Name + "</td>";
                html += "<td>" + item.Description + "</td>";                
                html += "<td><div class\"btn-group\">" +
                    "<a class=\"btn btn-outline-danger btn-xs mr-1\" href=\"javascript:Update('"+item.Id+"')\"><i class=\"fas fa-pencil-alt\"></i> </a>" +
                    "<a class=\"btn btn-outline-danger btn-xs\" href=\"javascript:Deleted('" + item.Id +"')\"><i class=\"fas fa-trash-alt\"></i> </a>"
                "</div></td> ";
                html += "</tr>";
            }
        }
        else {
            html += "<tr><td colspan=\"10\" style=\"text-align:center\">Không có dữ liệu</td></tr>";
        }
        $("#tblData").html(html);
    };

    self.WrapPaging = function (recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / tedu.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                tedu.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }

    self.GetDataPaging = function (isPageChanged) {
        var _data = {
            Name: $(".name-search").val() != "" ? $(".name-search").val() : null,
            Code: $(".code-search").val() != "" ? $(".code-search").val() : null,
            PageIndex: tedu.configs.pageIndex,
            PageSize: tedu.configs.pageSize
        };
        $.ajax({
            url: '/Admin/Role/GetAllPaging',
            type: 'GET',
            data: _data,
            dataType: 'json',
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                //Loading('hiden');
            },
            success: function (response) {
                self.RenderTableHtml(response.data.Results);
                $('#lblTotalRecords').text(response.data.RowCount);
                if (response.data.RowCount != null && response.data.RowCount > 0) {
                    self.WrapPaging(response.data.RowCount, function () {
                        GetDataPaging();
                    }, isPageChanged);
                }

            }
        })

    };


    self.Update = function (id) {
        if (id != null && id != "") {
            self.GetById(id, self.RenderHtmlByUser);
            //self.RenderHtmlByUser(user);
            $('#_add').modal('show');
            self.IsUpdate = true;
        }
    }
    self.Deleted = function (id) {
        if (id != null && id != "") {
            tedu.confirm('Bạn có chắc muốn xóa quyền?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Role/Delete",
                    data: { id: id },
                    beforeSend: function () {
                       // tedu.startLoading();
                    },
                    success: function () {
                        //tedu.notify('Delete successful', 'success');
                        //tedu.stopLoading();
                        //loadData();
                        self.GetDataPaging(true);
                    },
                    error: function () {
                        tedu.notify('Has an error', 'error');
                        tedu.stopLoading();
                    }
                });
            });
        }
    }
    self.RenderHtmlByUser = function (role) {
        $(".name").val(role.Name);
        $(".description").val(role.Description);
    }

    self.GetById = function (id,renderCallBack) {
        //self.userData = {};
        if (id != null && id != "") {
            $.ajax({
                url: '/Admin/Role/GetById',
                type: 'GET',
                dataType: 'json',
                data: {
                    id: id
                },
                beforeSend: function () {
                    Loading('show');
                },
                complete: function () {
                    //Loading('hiden');
                },
                success: function (response) {
                    if (response.Data != null) {
                        renderCallBack(response.Data);
                        self.RoleId = id;
                    }
                }
            })
        }
        //return self.userData;

    }

    self.FormatDate = function (date) {
        if (typeof date == "string")
            date = new Date(date);
        var day = (date.getDate() <= 9 ? "0" + date.getDate() : date.getDate());
        var month = (date.getMonth() + 1 <= 9 ? "0" + (date.getMonth() + 1) : (date.getMonth() + 1));
        var dateString = day + "/" + month + "/" + date.getFullYear()

        return dateString;
    }

    self.GetData = function () {
        $.ajax({
            url: '/Admin/Role/GetAll',
            type: 'GET',
            dataType: 'json',
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                //Loading('hiden');
            },
            success: function (response) {
                if (response.IsData) {
                    self.Data = response.Data;
                }
                self.RenderTableHtml();
                Loading('hiden');
            }
        })

    };

    self.FormSubmitAdd = function () {
        $('#formSubmitAdd').validate({
            rules: {
                name: {
                    required: true,
                },
                description: {
                    required: true,
                }
            },
            messages: {
                name: {
                    required: "Bạn chưa quyền",
                },
                description: {
                    required: "Bạn chưa nhập mô tả",
                }
            },
            submitHandler: function () {
                var roleView = {
                    Id: self.RoleId,
                    Name: $(".name").val(),
                    Description: $(".description").val(),
                }
                if (self.IsUpdate) {

                    $.ajax({
                        url: '/Admin/Role/Update',
                        type: 'POST',
                        data: {
                            roleModelView: roleView
                        },
                        dataType: 'json',
                        beforeSend: function () {
                            Loading('show');
                        },
                        complete: function () {
                            Loading('hiden');
                        },
                        success: function (response) {
                            if (response.success) {
                                self.GetDataPaging(true);
                                $('#_add').modal('hide');
                            }
                        }
                    })


                }
                else {
                    $.ajax({
                        url: '/Admin/Role/Add',
                        type: 'POST',
                        data: {
                            roleModelView: roleView
                        },
                        dataType: 'json',
                        beforeSend: function () {
                            Loading('show');
                        },
                        complete: function () {
                            Loading('hiden');
                        },
                        success: function (response) {
                            if (response.success) {
                                self.GetDataPaging(true);
                                $('#_add').modal('hide');
                            }
                        }
                    })
                }
              
            }
        });
    };


    $(document).ready(function () {
        self.GetDataPaging();
        $("#dpicker").datepicker();
        self.FormSubmitAdd();

        $(".modal").on("hidden.bs.modal", function () {
            $(this).find('form').trigger('reset');
            $("#formSubmitAdd").validate().resetForm();
            $("label.error").hide();
            $(".error").removeClass("error");
        });


    });

})(jQuery);