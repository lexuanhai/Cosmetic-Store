(function ($) {
    var self = this;
    self.Data = [];
    self.IsUpdate = false;
    self.RoleId = "";
    self.RenderTableHtml = function () {
        var html = "";
        if (self.Data != "" && self.Data.length > 0) {
            for (var i = 0; i < self.Data.length; i++) {
                html += "<tr>";
                var item = self.Data[i];
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
            html += "<tr>Không có dữ liệu</tr>";
        }
        $("#tblData").html(html);
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
            tedu.confirm('Bạn có chắc muốn xóa role?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Role/Delete",
                    data: { roleId: id },
                    beforeSend: function () {
                       // tedu.startLoading();
                    },
                    success: function () {
                        //tedu.notify('Delete successful', 'success');
                        //tedu.stopLoading();
                        //loadData();
                        GetData();
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
                                self.GetData();
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
                                self.GetData();
                                $('#_add').modal('hide');
                            }
                        }
                    })
                }
              
            }
        });
    };


    $(document).ready(function () {
        GetData();
        $("#dpicker").datepicker();
        self.FormSubmitAdd();

        $(".modal").on("hidden.bs.modal", function () {
            $(this).find('form').trigger('reset');
        });

    });

})(jQuery);