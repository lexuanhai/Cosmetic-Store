(function ($) {
    var self = this;
    self.Data = [];
    self.IsUpdate = false;
    self.Id = "";
    self.RenderTableHtml = function (data) {
        var html = "";
        if (data != "" && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];                
                html += "<tr>";
                html += "<td>" + item.Name + "</td>";
                html += "<td>" + item.Code + "</td>";
                html += "<td><a herf=\"javascript:void(0)\" style=\"background-color:" + item.Code+"\" class=\"color-show\"></a></td>";
                html += "<td><div class\"btn-group\">" +
                    "<a class=\"btn btn-outline-danger btn-xs mr-1\" href=\"javascript:Update('" + item.Id + "')\"><i class=\"fas fa-pencil-alt\"></i> </a>" +
                    "<a class=\"btn btn-outline-danger btn-xs\" href=\"javascript:Deleted('" + item.Id + "')\"><i class=\"fas fa-trash-alt\"></i> </a>"
                "</div></td> ";
                html += "</tr>";
            }
        }
        else {
            html += "<tr><td colspan=\"4\" style=\"text-align:center\">Không có dữ liệu</td></tr>";
        }
        $("#tblData").html(html);
    };

    self.Update = function (id) {
        if (id != null && id != "") {
            self.GetById(id, self.RenderHtmlByObject);
            //self.RenderHtmlByUser(user);
            $('#_addUpdate').modal('show');
            self.IsUpdate = true;
        }
    }
    self.Deleted = function (id) {
        if (id != null && id != "") {
            tedu.confirm('Bạn có chắc muốn xóa màu?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Colors/Delete",
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
    self.RenderHtmlByObject = function (view) {
        $(".name").val(view.Name);
        $(".code").val(view.Code);
        $("#colorshow").css('background-color', view.Code);
    }

    self.GetById = function (id, renderCallBack) {
        //self.userData = {};
        if (id != null && id != "") {
            $.ajax({
                url: '/Admin/Colors/GetById',
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
                        self.Id = id;
                    }
                }
            })
        }
        //return self.userData;

    }       

    self.FormSubmitAdd = function () {
        $('#formSubmitAdd').validate({
            rules: {
                name: {
                    required: true,
                },
                code: {
                    required: true,
                }
            },
            messages: {
                name: {
                    required: "Bạn chưa nhập tên Colors",
                },
                code: {
                    required: "Bạn chưa nhập tên mã màu",
                }
            },
            submitHandler: function () {                
                var View = {
                    Id: self.Id,
                    Name: $(".name").val(),
                    Code: $(".code").val()
                }
                if (self.IsUpdate) {
                    $.ajax({
                        url: '/Admin/Colors/Update',
                        type: 'POST',
                        data: {
                            ColorsModelView: View
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
                                self.GetDataPaging(false);
                                $('#_addUpdate').modal('hide');
                            }
                        }
                    })
                }
                else {
                    $.ajax({
                        url: '/Admin/Colors/Add',
                        type: 'POST',
                        data: {
                            colorModelView: View
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
                                $('#_addUpdate').modal('hide');
                            }
                        }
                    })
                }

            }
        });
    };

    self.GetDataPaging = function (isPageChanged) {
        var _data = {
            Name: $(".name-search").val() != "" ? $(".name-search").val() : null,
            Code: $(".code-search").val() != "" ? $(".code-search").val() : null,
            PageIndex: tedu.configs.pageIndex,
            PageSize: tedu.configs.pageSize
        };
        $.ajax({
            url: '/Admin/Colors/GetAllPaging',
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

    $(document).ready(function () {     
        self.GetDataPaging();
        self.FormSubmitAdd();

        $(".modal").on("hidden.bs.modal", function () {
            $(this).find('form').trigger('reset');
        });


        $(".btn-submit-search").click(function () {
            self.GetDataPaging(true);
        });

        $('#boxSearch').on('hidden.bs.collapse', function () {
            $('.name-search').val("");
            $('.code-search').val("");
            self.GetDataPaging(true);
        })
        $(".code").keyup(function () {
            $("#colorshow").css('background-color', $(this).val());
        });


    });

})(jQuery);