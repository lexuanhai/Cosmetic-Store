(function ($) {
    var self = this;
    self.Data = [];
    self.UserImages = {};
    self.IsUpdate = false;
    self.User = {
        Id: null,
        FullName: null,
        BirthDay: null,
        UserName: "",
        Email: "",
        Address: "",
        PhoneNumber: "",
        Avatar: ""
    }
    self.UserSearch = {
        Id: "",
        FullName: null,
        Birthday: null,
        UserName: "",
        Email: "",
        Address: "",
        Phone: "",
    }
    self.lstRole = [];

    self.addSerialNumber = function () {
        var index = 0;
        $("table tbody tr").each(function (index) {
            $(this).find('td:nth-child(1)').html(index + 1);
        });
    };
    self.Files = {};

    self.RenderTableHtml = function (data) {
        var html = "";
        if (data != "" && data.length > 0) {
            var index = 0;
            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                html += "<tr>";
                html += "<td>" + (++index) + "</td>";
                html += "<td>" + item.UserName + "</td>";
                html += "<td>" + item.Name + "</td>";
                html += "<td>" + item.Name + "</td>";
                html += "<td>" + item.Phone + "</td>";
                html += "<td>" + item.Email + "</td>";
                html += "<td>" + item.BirthdayStr + "</td>";
                html += "<td>" + item.Address + "</td>";
                html += "<td><img class='fisrt-image-product' src=" + (item.Avartar != null && item.Avartar != "" ? item.Avartar : "/image/default-image-620x600.jpg") + "></td>";
                html += "<td><div class\"btn-group\">" +
                    "<a class=\"btn btn-outline-danger btn-xs mr-1\" href=\"javascript:Update('" + item.Id + "')\"><i class=\"fas fa-pencil-alt\"></i> </a>" +
                    "<a class=\"btn btn-outline-danger btn-xs\" href=\"javascript:Deleted('" + item.Id + "')\"><i class=\"fas fa-trash-alt\"></i> </a>"
                "</div></td> ";
                html += "</tr>";
            }
        }
        else {
            html += "<tr><td colspan=\"9\" style=\"text-align:center\">Không có dữ liệu</td></tr>";
        }
        $("#tblData").html(html);
    };
    self.Update = function (id) {
        if (id != null && id != "") {
            $(".txt-title-head").html("Cập nhật thông tin nhân viên");
            self.GetById(id, self.RenderHtmlByObject);

            //self.RenderHtmlByUser(user);
            $('#CreateOrUpdate').modal('show');
            //$(".content-infor").hide();
            //$(".box-content-add").show();

            self.IsUpdate = true;
        }
    }

    self.GetById = function (id, renderCallBack) {
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
                        //self.GetImageByProductId(id);
                        renderCallBack(response.Data);
                        self.Id = id;
                    }
                }
            })
        }
    }

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
    self.Deleted = function (id) {
        if (id != null && id != "") {
            tedu.confirm('Bạn có chắc muốn xóa nhân viên?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/AppUsers/Delete",
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

    self.GetDataPaging = function (isPageChanged) {
        var _data = {
            Name: $(".name-search").val() != "" ? $(".name-search").val() : null,
            Code: $(".code-search").val() != "" ? $(".code-search").val() : null,
            PageIndex: tedu.configs.pageIndex,
            PageSize: tedu.configs.pageSize
        };
        $.ajax({
            url: '/Admin/AppUsers/GetAllPaging',
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


    self.Init = function () {
        //self.GetUser();
        //self.GetAllRole();


        $(".btn-add").click(function () {
            //self.BindRoleHtml();
            //;           
            self.SetValueDefault();
            $('#CreateOrUpdate').modal('show')
        })

        // hủy add và edit
        $(".cs-close-addedit,.btn-cancel-addedit").click(function () {
            $("#CreateEdit").css("display", "none");
        })

        

        $(".filesImages").change(function () {
            var files = $(this).prop('files')[0];

            var t = files.type.split('/').pop().toLowerCase();

            if (t != "jpeg" && t != "jpg" && t != "png" && t != "bmp" && t != "gif") {
                alert('Vui lòng chọn một tập tin hình ảnh hợp lệ!');
                //$("#avatar").val("");
                return false;
            }

            if (files.size > 2048000) {
                alert('Kích thước tải lên tối đa chỉ 2Mb');
                //$("#avatar").val("");
                return false;
            }

            var img = new Image();
            img.src = URL.createObjectURL(files);
            img.onload = function () {
                CheckWidthHeight(this.width, this.height);
            }
            var CheckWidthHeight = function (w, h) {
                if (w <= 300 && h <= 300) {
                    alert("Ảnh tối thiểu 300 x 300 px");
                }
                else {
                    $(".box-avatar").css({ 'background': 'url(' + img.src + ')', 'display': 'block' });                   
                    self.UserImages = files;
                    //console.log(self.UserImages);
                }
            }

        })


        //$('.filesImages').on('change', function () {
        //    var fileUpload = $(this).get(0);
        //    var files = fileUpload.files;
        //    if (files != null && files.length > 0) {
        //        var fileExtension = ['jpeg', 'jpg', 'png'];
        //        var html = "";
        //        for (var i = 0; i < files.length; i++) {
        //            if ($.inArray(files[i].type.split('/')[1].toLowerCase(), fileExtension) == -1) {
        //                alert("Only formats are allowed : " + fileExtension.join(', '));
        //            }
        //            else {
        //                console.log(files[i]);
        //                self.FileImages.push(files[i]);
        //                var src = URL.createObjectURL(files[i]);
        //                html += "<div class=\"box-item-image\"> <div class=\"image-upload item-image\" style=\"background-image:url(" + src + ")\"></div><a href=\"javascript:void(0)\" class=\"item-delete\" onclick=\"DeleteImage(0,this)\">Xóa</a></div>";
        //            }
        //        }
        //        if (html != "") {
        //            $(".image-default").hide();
        //            $(".box-images").append(html);
        //        }
        //    }

        //});


        $("#birthday").datepicker({
            changeMonth: true,
            changeYear: true,
        });

        $(".btn-submit-search").click(function () {
            var id = $("#code_user_search").val();
            var fullName = $('#fullname_user_search').val();
            var userName = $('#name_user_search').val();
            var email = $('#email_user_search').val();
            var address = $('#address_user_search').val();
            var phoneNumber = $('#phone_user_search').val();
            var birthDay = $('#birthday_user_search').val();

            self.UserSearch = {
                Id: id,
                FullName: fullName,
                UserName: userName,
                Email: email,
                Address: address,
                Phone: phoneNumber,
                Birthday: birthDay,
            }
            self.GetUser(self.UserSearch);
        })

        $('body').on('click', '.btn-edit', function () {
            $(".user .modal-title").text("Chỉnh sửa thông tin người dùng");
            var id = $(this).attr('data-id');
            if (id !== null && id !== undefined) {
                self.GetUserById(id);
                $('#create').modal('show');
            }
        })

        $('.add-role').click(function () {
            $('#AddRole').modal('show');
        })

        $('body').on('click', '.btn-delete', function () {
            var id = $(this).attr('data-id');
            var fullname = $(this).attr('data-fullname');
            if (id !== null && id !== '') {
                self.confirmUser(fullname, id);
            }
        })
        $(".add-image").click(function () {
            $("#file-input").click();
        })

        $('body').on('click', '.btn-role-user', function () {
            var id = $(this).attr('data-id');
            $("#user_id").val(id);
            //self.GetAllRoles(id);           
        })

        $('body').on('click', '.btn-set-role', function () {
            var userId = parseInt($("#user_id").val());
            $.each($("#lst-role tr"), function (key, item) {
                var check = $(item).find('.ckRole').prop('checked');
                if (check == true) {
                    var id = parseInt($(item).find('.ckRole').val());
                    self.lstRole.push({
                        UserId: userId,
                        RoleId: id
                    });
                }
            })
            if (self.lstRole.length > 0) {
                self.SaveRoleForUser(self.lstRole, userId);
            }

        })

        $('.filesImages').on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            if (files != null && files.length > 0) {
                var fileExtension = ['jpeg', 'jpg', 'png'];
                var html = "";
                for (var i = 0; i < files.length; i++) {
                    if ($.inArray(files[i].type.split('/')[1].toLowerCase(), fileExtension) == -1) {
                        alert("Only formats are allowed : " + fileExtension.join(', '));
                    }
                    else {
                        //console.log(files[i]);
                        //self.FileImages.push(files[i]);
                        var src = URL.createObjectURL(files[i]);
                        html += "<div class=\"box-item-image\"> <div class=\"image-upload item-image\" style=\"background-image:url(" + src + ")\"></div></div>";
                    }
                }
                if (html != "") {
                    $(".image-default").hide();
                    $(".box-images").html(html);
                }
            }

        });
    }

    self.confirmUser = function (nameUser, id) {
        bootbox.confirm({
            message: '<div class="title-delete"><p>Bạn có chắc muốn xóa người dùng này?</p><p>' + nameUser + '</p></div>',
            centerVertical: true,
            buttons: {
                confirm: {
                    label: 'Đồng ý',
                    className: 'btn-success pull-left'
                },
                cancel: {
                    label: 'Hủy',
                    className: 'btn-danger '
                }
            },
            callback: function (result) {
                if (result === true) {
                    $.ajax({
                        type: "POST",
                        url: "/Admin/User/Delete",
                        dataType: "json",
                        data: {
                            id: id
                        },
                        beforeSend: function () {
                        },
                        complete: function () {
                        },
                        success: function (res) {
                            if (res.status) {
                                self.GetUser();
                                Notifly(res.message, "success");
                            }
                            else {
                                $.notify(res.message, 'error');
                            }
                        },
                        error: function () {
                        }
                    });
                }
            }
        });
    }

    self.SaveRoleForUser = function (userRoles, userId) {
        $.ajax({
            type: "POST",
            url: "/Admin/AppUsers/SaveRoleForUser",
            data: {
                userRoles: userRoles,
                userId: userId
            },
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (response) {
                if (response.Status == true) {
                    $('#assignrole').modal('hide');
                    $.notify("Gán quyền thành công", 'success');
                }
                else {
                    $.notify("Gán quyền không thành công", 'error');
                }
                self.lstRole = [];
            },
            error: function (eror) {
                console.log(eror);
            }
        });
    }


    self.AddImageAvatar = function () {
        var dataImage = new FormData();
        dataImage.append("image1", self.UserImages);
        $.ajax({
            url: '/Admin/AppUsers/UploadImageAvatar',
            type: 'POST',
            contentType: false,
            processData: false,
            data: dataImage,
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                Loading('hiden');
            },
            success: function (response) {
                //if (response.success) {
                //    self.GetDataPaging(true);
                //    $('#_addUpdate').modal('hide');
                //}
            }
        })
    }


    //self.GetAllRoles = function (userId) {
    //    $.ajax({
    //        type: "GET",
    //        url: "/Admin/Role/GetAllRole",
    //        dataType: "json",
    //        beforeSend: function () {
    //        },
    //        complete: function () {
    //        },
    //        success: function (response) {

    //            if (response.Data !== null && response.Data.length > 0) {
    //                var data = response.Data;
    //                var html = "";
    //                $.each(data, function (key, item) {
    //                    html += '<tr data-id="' + item.Id + '">' +
    //                        "<td>" + item.Name + "</td>" +
    //                        "<td><label><input type='checkbox' value=" + item.Id + " class='ckRole'></label></td>" +
    //                        "</tr> ";
    //                })

    //                $("#lst-role").html(html);

    //                if (userId > 0) {
    //                    self.GetRoleByUserId(userId);
    //                }

    //            }

    //        },
    //        error: function () {
    //        }
    //    });
    //}

    self.GetRoleByUserId = function (userId) {
        $.ajax({
            type: "GET",
            url: "/Admin/AppUsers/GetRoleByUserId",
            data: {
                userId: userId
            },
            dataType: "json",
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (response) {
                if (response.Status) {
                    var data = response.Data;
                    $.each($("#lst-role tr"), function (key, item) {
                        $.each(data, function (i, items) {
                            if (items.RoleId === parseInt($(item).data("id"))) {
                                $(item).find(".ckRole").prop("checked", true);
                            }
                        })

                    })
                }
                $('#assignrole').modal('show');

            },
            error: function () {
            }
        });
    }

    self.GetUserById = function (id) {
        $.ajax({
            type: "GET",
            url: "/Admin/AppUsers/GetUserById",
            dataType: "json",
            data: {
                id: id
            },
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (response) {
                if (response.Status) {
                    var resUser = response.Data.UserVM;
                    self.User.Id = resUser.Id;
                    self.User.FullName = resUser.FullName;
                    self.User.BirthDay = resUser.BirthDay;
                    self.User.UserName = resUser.UserName;
                    self.User.Email = resUser.Email;
                    self.User.Address = resUser.Address;
                    self.User.PhoneNumber = resUser.PhoneNumber;
                    self.User.Avatar = resUser.Avatar;
                    Set.SetValue();
                }
            },
            error: function () {
            }
        });
    }
    // Set value default
    self.SetValueDefault = function () {
        self.User.Id = null;
        $("#fullname").val("").attr("placeholder", "Nhập tên người dùng");
        $("#mobile").val("").attr("placeholder", "Nhập số điện thoại");
        $("#birthday").val("").attr("placeholder", "Ngày sinh");
        $("#email").val("").attr("placeholder", "Email");
        $("#username").val("").attr("placeholder", "Tên đăng nhập");
        $("#password").val("").attr("placeholder", "Mật khẩu");
        $("#address").val("").attr("placeholder", "Địa chỉ");
        $("#confirm_password").val("").attr("placeholder", "Nhập lại mật khẩu");
        $(".box-avatar").css("display", "none");
    }
    // Get User
    self.GetUser = function () {
        $.ajax({
            type: "GET",
            url: "/Admin/AppUsers/GetAllUser",
            dataType: "json",
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (response) {
                var data = response
                if (data != null && data.length > 0) {
                    var html = "";
                    $.each(data, function (key, item) {

                        html += "<tr>" +
                            "<td></td>" +
                            "<td>" + item.FullName + "</td>" +
                            '<td> <div class="img-avatar" style="background:url(/image/admin/avatar.jpg)"><img src="/' + (item.Avatar != null ? item.Avatar : "image/admin/avatar.jpg") + '"/></div></td>' +
                            "<td>" + item.UserName + "</td>" +
                            "<td>" + item.PhoneNumber + "</td>" +
                            "<td>" + (item.Email !== null && item.Email !== "" ? item.Email : "") + "</td>" +
                            "<td>" + (item.BirthDay !== null ? dateFormatJson(item.BirthDay) : "") + "</td>" +
                            "<td>" + (item.Address !== null && item.Address !== "" ? item.Address : "") + "</td>" +
                            //"<td>" + (item.CreatedDate !== null ? dateFormatJson(item.CreatedDate) : "") + "</td>" +
                            //"<td>" + (item.UpdatedDate !== null ? dateFormatJson(item.UpdatedDate) : "") + "</td>" +
                            '<td>' +
                            '<a class="btn-role-user fa fa-user-secret fa-lg" title = "gán role" data-id=' + item.Id + ' data-id=' + item.Id + '  href="javascript:void(0)" ></a >' +
                            '<a class="btn-edit fa fa-pencil-square fa-lg" title = "Sửa" data-id=' + item.Id + ' data-id=' + item.Id + '  href="javascript:void(0)" ></a >' +
                            '<a class="btn-delete fa fa-trash-o fa-lg" data-id=' + item.Id + ' data-fullname ="' + item.FullName + '" title="xóa" href="javascript:void(0)"></a>' +
                            '</td >' +
                            "</tr>";
                    });
                }
                else {
                    html += '<tr><td colspan="8"> <a class="come-black" href="javascript:void(0)">Không có dữ liệu</a>  </td></tr>'
                }

                $(".table-content").html(html);

                self.addSerialNumber();
            },
            error: function () {
            }
        });
    }

    self.AddUser = function (userView) {
        $.ajax({
            url: '/Admin/AppUsers/Add',
            type: 'POST',
            dataType: 'json',
            data: {
                UserModelView: userView
            },
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                Loading('hiden');
            },
            success: function (response) {
                if (response.success) {
                    if (self.UserImages != null) {
                        self.AddImageAvatar();
                    }
                    setTimeout(function () {
                        window.location.reload();
                    }, 500);
                }
            }
        })
    }

    self.UpdateUser = function (userView) {
        $.ajax({
            url: '/Admin/AppUsers/Update',
            type: 'POST',
            dataType: 'json',
            data: {
                UserModelView: userView
            },
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                Loading('hiden');
            },
            success: function (response) {
                if (response.success) {
                    if (self.UserImages != null) {
                        self.AddImageAvatar();
                    }                    
                    setTimeout(function () {
                        window.location.reload();
                    }, 500);
                }
            }
        })
    }

    self.ValidateUser = function () {        
        jQuery.validator.addMethod("headphone", function (value, element) {
            var vnf_regex = /((032|033|034|035|036|037|038|039|056|058|059|070|076|077|078|079|081|082|083|084|085|086|087|088|089|090|091|092|093|094|096|097|098|099)+([0-9]{7})\b)/g;
            return vnf_regex.test(value);
        });
        jQuery.validator.addMethod("rigidemail", function (value, element) {
            var testemail = /^([^@\s]+)@((?:[-a-z0-9]+\.)+[a-z]{2,})$/i;
            return testemail.test(value);
        });

        $("#form_user").validate({
            rules:
            {
                fullname: {
                    required: true,
                },
                mobile: {
                    required: true,
                    //headphone: false,
                    minlength: 10,
                    min: 0,
                    maxlength: 10,
                    number: isNaN
                },
                birthday: {
                    required: true,
                },
                address: {
                    required: true,
                },
                username: {
                    required: true,
                },
                password: {
                    required: true
                },
                confirm: {
                    required: true,
                    equalTo: "#confirm_password"
                }
            },
            messages:
            {
                fullname: {
                    required: "Bạn chưa nhập tên.",
                },
                mobile: {
                    required: "Bạn chưa nhập số điện thoại",
                    headphone: "Số điện thoại không hợp lệ"
                },
                //birthday: {
                //    required: "Bạn chưa nhập ngày sinh",
                //},
                address: {
                    required: "Bạn chưa nhập địa chỉ",
                },
                username: {
                    required: "Bạn chưa nhập tên đăng nhập",
                },
                password: {
                    required: "Bạn chưa nhập mật khẩu",
                    min: "Mật khẩu ít nhất 6 kí tự"
                },
                confirm: {
                    required: "Bạn chưa nhập lại mật khẩu.",
                    equalTo: "Mật khẩu không đúng.",
                    min: "Mật khẩu ít nhất 6 kí tự"
                }
            },
            submitHandler: function (form) {
                
                self.GetValue();

                if (self.UserImages != null) {
                    self.User.Avartar = "/avatar/"+self.UserImages.name;
                }
                if (self.IsUpdate) {                    
                    self.UpdateUser(self.User);
                }
                else {                    
                    self.AddUser(self.User);
                }
            }
        });
    }

    self.GetValue = function () {
        self.User.Name = $("#fullname").val();
        self.User.Phone = $("#mobile").val();
        self.User.Email = $("#email").val();
        self.User.Address = $("#address").val();
        self.User.UserName = $("#username").val();
        self.User.Password = $("#password").val();
        self.User.BirthDay = $("#birthday").val();

    }

    Set.SetValue = function () {
        if (self.User.Id !== null && self.User.Id !== '') {
            $("#fullname").val(self.User.FullName);
            $("#mobile").val(self.User.PhoneNumber);
            $("#email").val(self.User.Email);
            $("#address").val(self.User.Address);
            $("#username").val(self.User.UserName);
            $("#password").val(self.User.Password);
            $("#birthday").val(moment(self.User.BirthDay).format('DD/MM/YYYY'));
            $(".box-avatar").css({ 'background': 'url(/' + (self.User.Avatar !== null ? self.User.Avatar : "image/admin/avatar.jpg") + ')', 'display': 'block' });
        }
    }

    self.RenderHtmlByObject = function (view) {
        console.log(view);
        $("#fullname").val(view.FullName);
        $("#mobile").val(view.PhoneNumber);
        $("#email").val(view.Email);
        $("#address").val(view.Address);
        $("#username").val(view.UserName);
        $("#password").val(view.Password);
        $("#birthday").val(moment(view.BirthDay).format('DD/MM/YYYY'));
        $(".box-avatar").css({ 'background': 'url(/' + (view.Avatar !== null ? view.Avatar : "image/admin/avatar.jpg") + ')', 'display': 'block' });

    }

    self.SubmitUser = function (user) {
        var form_data = new FormData();

        form_data.append("Id", self.User.Id);
        form_data.append("FullName", self.User.FullName);
        form_data.append("PhoneNumber", self.User.PhoneNumber);
        form_data.append("Email", self.User.Email);
        form_data.append("Address", self.User.Address);
        form_data.append("UserName", self.User.UserName);
        form_data.append("Password", self.User.Password);

        //var roles = [];
        //$.each($('input[name="ckRoles"]'), function (i, item) {
        //    if ($(item).prop('checked') === true)
        //        roles.push($(item).prop('value'));
        //});
        //if (roles.length > 0) {
        //    $.each(roles, function (key, item) {
        //        form_data.append("Roles", item);
        //    })
        //}

        //form_data.append("BirthDayTest", self.User.BirthDay);
        //form_data.append("BirthDay", new Date(date).toUTCString());
        //form_data.append("Files", self.Files);
        $.ajax({
            type: "POST",
            url: "/Admin/AppUsers/SaveEntity",
            data: form_data,
            contentType: false,
            processData: false,
            beforeSend: function () {
            },
            complete: function () {
                $(".add-edit-user").css("display", "inline-block");
            },
            success: function (response) {
                if (response.Status == true) {
                    //self.GetUser();
                    $('#create').modal('hide');
                    $.notify(response.message, 'success');
                }
                else {
                    $.notify(response.message, 'error');
                }
            },
            error: function (eror) {
                console.log(eror);
            }
        });
    }

    self.GetAllRole = function () {
        $.ajax({
            type: "GET",
            url: "/Admin/Role/GetAll",
            dataType: "json",
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (response) {
                if (response !== null && response.length > 0) {
                    self.lstRole = response;
                }
            },
            error: function () {
            }
        });
    }
    self.BindRoleHtml = function (selectedRole) {
        if (self.lstRole !== null && self.lstRole.length > 0) {
            var html = "";
            $.each(self.lstRole, function (key, item) {

                html += '<div class="item-checkbox">' +
                    '<input type = "checkbox" class="checkbox" value="' + item.Name + '" name="ckRoles" />' +
                    '<span class="name-role">' + item.Name + '</span> </div >';
            })
            $(".list-roles").html(html);
        }
    }

    $(document).ready(function () {
        self.GetDataPaging();
        self.Init();
        self.ValidateUser();
    })
})(jQuery);