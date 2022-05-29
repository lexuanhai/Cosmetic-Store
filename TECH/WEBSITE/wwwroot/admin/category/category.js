(function ($) {
    var self = this;
    self.Data = [];
    self.IsUpdate = false;
    self.Id = "";
    //self.RenderTableHtml = function () {
    //    var html = "";
    //    if (self.Data != "" && self.Data.length > 0) {
    //        for (var i = 0; i < self.Data.length; i++) {
    //            var item = self.Data[i];  
    //            var nameParent = (item.ParentName != "" && item.ParentName != null) ? item.ParentName : "";
    //            html += "<tr>";

    //            html += "<td>" + item.Name + "</td>";
    //            html += "<td>" + nameParent + "</td>";
    //            html += "<td><div class\"btn-group\">" +
    //                "<a class=\"btn btn-outline-danger btn-xs mr-1\" href=\"javascript:Update('"+item.Id+"')\"><i class=\"fas fa-pencil-alt\"></i> </a>" +
    //                "<a class=\"btn btn-outline-danger btn-xs\" href=\"javascript:Deleted('" + item.Id +"')\"><i class=\"fas fa-trash-alt\"></i> </a>"
    //            "</div></td> ";
    //            html += "</tr>";
    //        }
    //    }
    //    else {
    //        html += "<tr>Không có dữ liệu</tr>";
    //    }
    //    $("#tblData").html(html);
    //};

    self.RenderTableHtml = function (data) {
        //console.log(data);
        var html = "";
        if (data != "" && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                var nameParent = (item.ParentName != "" && item.ParentName != null) ? item.ParentName : "";
                html += "<tr>";

                html += "<td>" + item.Name + "</td>";
                html += "<td>" + nameParent + "</td>";
                html += "<td><div class\"btn-group\">" +
                    "<a class=\"btn btn-outline-danger btn-xs mr-1\" href=\"javascript:Update('" + item.Id + "')\"><i class=\"fas fa-pencil-alt\"></i> </a>" +
                    "<a class=\"btn btn-outline-danger btn-xs\" href=\"javascript:Deleted('" + item.Id + "')\"><i class=\"fas fa-trash-alt\"></i> </a>"
                "</div></td> ";
                html += "</tr>";
            }
        }
        else {
            html += "<tr>Không có dữ liệu</tr>";
        }
        $("#tblData").html(html);
    };

    self.Update = function (id) {
        if (id != null && id != "") {
            self.GetById(id, self.RenderHtmlByObject);
            //self.RenderHtmlByUser(user);
            $('#_add').modal('show');
            self.IsUpdate = true;
        }
    }
    self.Deleted = function (id) {
        if (id != null && id != "") {
            tedu.confirm('Bạn có chắc muốn xóa user?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Category/Delete",
                    data: { id: id },
                    beforeSend: function () {
                        // tedu.startLoading();
                    },
                    success: function () {
                        //tedu.notify('Delete successful', 'success');
                        //tedu.stopLoading();
                        //loadData();
                        self.GetData();
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
        $(".parentname").val(view.ParentId);
    }

    self.GetById = function (id, renderCallBack) {
        //self.userData = {};
        if (id != null && id != "") {
            $.ajax({
                url: '/Admin/Category/GetById',
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
            url: '/Admin/Category/GetAll',
            type: 'GET',
            dataType: 'json',
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                //Loading('hiden');
            },
            success: function (response) {
                if (response.Data != null && response.Data.length > 0) {
                    var html = "<option value=\"\">Chọn category parent</option>";
                    for (var i = 0; i < response.Data.length; i++) {
                        var data = response.Data[i];
                        html += "<option value=" + data.Id + ">" + data.Name + "</option>";
                    }
                    $(".nameparentcategory-search").html(html);
                    $(".parentname").html(html);
                }
            }
        })

    };

    self.GetAllParent = function () {
        $.ajax({
            url: '/Admin/Category/GetAllParent',
            type: 'GET',
            dataType: 'json',
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                //Loading('hiden');
            },
            success: function (response) {
                if (response.Data != null && response.Data.length > 0) {
                    var html = "<option value=\"\">Chọn category parent</option>";
                    for (var i = 0; i < response.Data.length; i++) {
                        var data = response.Data[i];
                        html += "<option value=" + data.Id + ">" + data.Name + "</option>";
                    }
                    $(".nameparentcategory-search").html(html);
                    $(".parentname").html(html);
                    // $('.parentname').select2();
                }
            }
        })

    };
    self.GetCategoryByParentId = function (parentId) {
        $.ajax({
            url: '/Admin/Category/GetCategoryByParentId',
            type: 'GET',
            data: {
                parentId: parentId
            },
            dataType: 'json',
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                //Loading('hiden');
            },
            success: function (response) {
                
                if (response.Data != null && response.Data.length > 0) {
                    var html = "<option value=\"\">Chọn category</option>";
                    for (var i = 0; i < response.Data.length; i++) {
                        var data = response.Data[i];
                        html += "<option value=" + data.Id + ">" + data.Name + "</option>";
                    }
                    $(".namecategory-search").html(html);
                }
                else {
                    $(".namecategory-search").empty();
                }
                
            }
        })

    };

    self.FormSubmitAdd = function () {
        $('#formSubmitAdd').validate({
            rules: {
                name: {
                    required: true,
                }
            },
            messages: {
                name: {
                    required: "Bạn chưa nhập tên Category",
                }
            },
            submitHandler: function () {
                var _parentId = $(".parentname").val() != "" && $(".parentname").val() != null ? parseInt($(".parentname").val()) : null;
                var View = {
                    Id: self.Id,
                    Name: $(".name").val(),
                    ParentId: _parentId
                }
                if (self.IsUpdate) {

                    $.ajax({
                        url: '/Admin/Category/Update',
                        type: 'POST',
                        data: {
                            categoryModelView: View
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
                                self.GetData();
                                $('#_add').modal('hide');
                            }
                        }
                    })


                }
                else {
                    $.ajax({
                        url: '/Admin/Category/Add',
                        type: 'POST',
                        data: {
                            categoryModelView: View
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
                                self.GetData();
                                $('#_add').modal('hide');
                            }
                        }
                    })
                }

            }
        });
    };

    self.GetDataPaging = function (isPageChanged) {
        var _data = {
            CategoryParentId: $(".nameparentcategory-search").val() != "" ? parseInt($(".nameparentcategory-search").val()) : null,
            CategoryId: $(".namecategory-search").val() != "" ? parseInt($(".namecategory-search").val()) : null,
            PageIndex: tedu.configs.pageIndex,
            PageSize: tedu.configs.pageSize
        };
        $.ajax({
            url: '/Admin/Category/GetAllPaging',
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
                self.WrapPaging(response.data.RowCount, function () {
                    GetDataPaging();
                }, isPageChanged);
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
        self.GetData();
        //self.GetAllParent();
        self.GetDataPaging();
        self.FormSubmitAdd();

        $(".modal").on("hidden.bs.modal", function () {
            $(this).find('form').trigger('reset');
        });

        $('.nameparentcategory-search').on('change', function (e) {         
            var valueSelected = this.value;
            if (valueSelected != "" && parseInt(valueSelected) > 0) {
                self.GetCategoryByParentId(valueSelected);
            }
        });

        $(".btn-submit-search").click(function () {
            self.GetDataPaging(true);
        });

        $('#boxSearch').on('hidden.bs.collapse', function () {
            $('.nameparentcategory-search').val("");
            $('.namecategory-search').empty();
            self.GetDataPaging(true);
        })
    });

})(jQuery);