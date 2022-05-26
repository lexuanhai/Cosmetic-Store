(function ($) {
    var self = this;
    self.Data = [];
    self.IsUpdate = false;
    self.UserId = "";
    self.RenderTableHtml = function () {
        var html = "";
        if (self.Data != "" && self.Data.length > 0) {
            for (var i = 0; i < self.Data.length; i++) {
                html += "<tr>";
                var item = self.Data[i];
                html += "<td>" + item.UserName + "</td>";
                html += "<td>" + item.Name + "</td>";
                html += "<td>" + item.Phone + "</td>";
                html += "<td>" + item.Email + "</td>";
                html += "<td>" + (item.Birthday != null ? self.FormatDate(item.Birthday) : "") + "</td>";
                html += "<td>" + item.Address + "</td>";
                html += "<td><div class\"btn-group\">" +
                    "<a class=\"btn btn-outline-danger btn-xs mr-1\" href=\"javascript:Update('"+item.Id+"')\"><i class=\"fas fa-pencil-alt\"></i> </a>" +
                    "<a class=\"btn btn-outline-danger btn-xs\" href=\"javascript:Deleted('" + item.Id +"')\"><i class=\"fas fa-trash-alt\"></i> </a>"
                "</div></td> ";
                html += "</tr>";
            }
        }
        else {
            html += "<tr><td>Không có dữ liệu</td></tr>";
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
            tedu.confirm('Bạn có chắc muốn xóa user?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/AppUsers/DeleteUser",
                    data: { userId: id },
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
    self.RenderHtmlByUser = function (user) {
        $(".username").val(user.UserName);
        $(".fullname").val(user.Name);
        $(".phone").val(user.Phone);
        $(".email").val(user.Email);
        /*$("#dpicker").datepicker("SetDate","06/01/21");*/
        $(".txtbirth").val(user.Birthday != null ? self.FormatDate(user.Birthday) : "");
        $(".address").val(user.Address);
    }

    self.GetById = function (id,renderCallBack) {
        //self.userData = {};
        if (id != null && id != "") {
            $.ajax({
                url: '/Admin/AppUsers/GetById',
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
                        self.UserId = id;
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
            url: '/Admin/AppUsers/GetAll',
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
                fullname: {
                    required: true,
                },
                username: {
                    required: true,
                },
                phone: {
                    required: true,
                },
                email: {
                    required: true,
                },
                birth: {
                    required: true,
                },
                address: {
                    required: true,
                }
            },
            messages: {
                fullname: {
                    required: "Bạn chưa nhập họ tên",
                },
                username: {
                    required: "Bạn chưa nhập User Name",
                },
                phone: {
                    required: "Bạn chưa nhập số điện thoại",
                },
                email: {
                    required: "Bạn chưa nhập email",
                },
                txtbirth: {
                    required: "Bạn chưa nhập ngày sinh",
                },
                address: {
                    required: "Bạn chưa nhập địa chỉ",
                }

            },
            submitHandler: function () {
                var userView = {
                    Id: self.UserId,
                    UserName: $(".username").val(),
                    Name: $(".fullname").val(),
                    Phone: $(".phone").val(),
                    Email: $(".email").val(),
                    Birthday: $(".txtbirth").val(),
                    address: $(".address").val(),
                }
                if (self.IsUpdate) {

                    $.ajax({
                        url: '/Admin/AppUsers/UpdateUser',
                        type: 'POST',
                        data: {
                            userModelView: userView
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
                        url: '/Admin/AppUsers/AddUser',
                        type: 'POST',
                        data: {
                            userModelView: userView
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