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
            ignore: [],
            //debug: false,
            rules: {
                name: {
                    required: true,
                },
                //subdecription: {
                //    required: true,
                //},
                //decription: {
                //    required: true
                //},
                categoryid: {
                    required: true
                },
                //selectstatus: {
                //    required: true
                //},
                price: {
                    required: true,
                },
                total: {
                    required: true,
                },
                manufacturingdate: {
                    required: true
                },
                expirydate: {
                    required: true
                }
                
            },
            messages: {
                name: {
                    required: "Bạn chưa nhập tên sản phẩm",
                },
                //subdecription: {
                //    required: "Bạn chưa nhập mô tả ngắn",
                //},
                //decription: {
                //    required: "Bạn chưa nhập mô tả chi tiết",
                //},   
                categoryid: {
                    required: "Bạn chọn danh mục",
                },
                //selectstatus: {
                //    required: "Bạn chọn trạng thái",
                //},
                price: {
                    required: "Bạn chưa nhập giá sản phẩm",
                },
                total: {
                    required: "Bạn chưa nhập giá tổng sản phẩm",
                },
                manufacturingdate: {
                    required: "Bạn chưa chọn ngày sản xuất",
                },
                expirydate: {
                    required: "Bạn chưa chọn hạn sử dụng",
                }
            },
            submitHandler: function () {
                //alert(1);
                var View = {
                    Id: 10                   
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
                    debugger;
                    var product = {
                        Name: $(".product-name").val(),
                        Decription: CKEDITOR.instances.txtContentdetail.getData(),
                        SubDecription: CKEDITOR.instances.txtsubContent.getData(),
                        Price: $(".price").val(),
                        ReducedPrice: $(".reduced-price").val(),
                        Total: $(".total").val(),
                        CategoryId: $(".categoryid").val(),
                        BrandsId: $(".brandsid").val(),
                    };
                    self.AddProduct(product);
                }

            }
        });
    };

    self.AddProduct = function (product) {
        debugger;
        $.ajax({
            url: '/Admin/Product/Add',
            type: 'POST',
            dataType: 'json',
            data: {
                productModelView: product
            },
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                Loading('hiden');
            },
            success: function (response) {
                if (response.success) {
                    self.UploadFileImageProduct(response.id);
                }
            }
        })
    }

    self.UploadFileImageProduct = function (productId) {
        var fileUpload = $(".filesImages").get(0);
        var files = fileUpload.files;
        var dataImage = new FormData();
        //dataImage.append("productId", productId);
        for (var i = 0; i < files.length; i++) {
            dataImage.append(productId, files[i]);
        }
        

        $.ajax({
            url: '/Admin/Product/UploadImageProduct',
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
                if (response.success) {
                    self.GetDataPaging(true);
                    $('#_addUpdate').modal('hide');
                }
            }
        })
    }
    self.ValidateFileImage = function (files) {
        for (var i = 0; i < files.length; i++) {

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
    self.GetAllColor = function () {
        $.ajax({
            url: '/Admin/Colors/GetAll',
            type: 'GET',
            dataType: 'json',
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                //Loading('hiden');
            },
            success: function (response) {
                var html = "<option value =\"\">Chọn colors</option>";
                if (response.Data != null && response.Data.length > 0) {
                    for (var i = 0; i < response.Data.length; i++) {
                        var item = response.Data[i];
                        html += "<option value =" + item.Id + ">" + item.Name + "</option>";
                    }
                }
                $(".colorsid").html(html);
            }
        })
    }    
    self.GetAllBrands = function () {
        $.ajax({
            url: '/Admin/Brands/GetAll',
            type: 'GET',
            dataType: 'json',
            beforeSend: function () {
                Loading('show');
            },
            complete: function () {
                //Loading('hiden');
            },
            success: function (response) {
                var html = "<option value =\"\">Chọn nhãn hiệu</option>";
                if (response.Data != null && response.Data.length > 0) {
                    for (var i = 0; i < response.Data.length; i++) {
                        var item = response.Data[i];
                        html += "<option value =" + item.Id + ">" + item.Name + "</option>";
                    }
                }
                $(".brandsid").html(html);
            }
        })
    }    
    self.GetAllCategories = function () {
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
                var html = "<option value =\"\">Chọn danh mục</option>";
                if (response.Data != null && response.Data.length > 0) {
                    for (var i = 0; i < response.Data.length; i++) {
                        var item = response.Data[i];
                        html += "<option value =" + item.Id + ">" + item.Name + "</option>";
                    }
                }
                $(".categoryid").html(html);
            }
        })
    }
    self.ShowSelect = function () {
        self.GetAllCategories();
        self.GetAllBrands();
        self.GetAllColor();
    }
    $(document).ready(function () {     
        self.GetDataPaging();
        self.FormSubmitAdd();
        self.ShowSelect();
        //CKEDITOR.on('instanceReady', function () {
        //    $.each(CKEDITOR.instances, function (instance) {
        //        CKEDITOR.instances[instance].document.on("keyup", self.FormSubmitAdd);
        //        CKEDITOR.instances[instance].document.on("paste", self.FormSubmitAdd);
        //        CKEDITOR.instances[instance].document.on("keypress", self.FormSubmitAdd);
        //        CKEDITOR.instances[instance].document.on("blur", self.FormSubmitAdd);
        //        CKEDITOR.instances[instance].document.on("change", self.FormSubmitAdd);
        //    });
        //});

        CKEDITOR.replace('txtsubContent', {
            toolbar: [																			
                //{ name: 'basicstyles', items: ['Bold', 'Italic'] },
                //{ name: "styles", items: ["Styles", "Format", "Font", "FontSize"] },
                //{ name: "colors", items: ["TextColor", "BGColor"] }
                { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'] },
                { name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Scayt'] },
                { name: 'links', items: ['Link', 'Unlink'] },
                { name: 'insert', items: ['Image', 'Table'] },
                '/',
                { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
                { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList'] },
                { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
                { name: "colors", items: ["TextColor", "BGColor"] }
            ]
        });

        CKEDITOR.replace('txtContentdetail', {});
        
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

        $(".customdate").datepicker({ dateFormat: 'dd/mm/yy' });        

        $(".add-image").click(function () {
            $("#file-input").click();
        })
        $(".btn-add").click(function () {
            $(".content-infor").hide();
            $(".box-content-add").show();
        })

        $('.filesImages').on('change', function () {
            debugger;
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            self.html = "";
            let src = [];
            for (var i = 0; i < files.length; i++) {            
                var img = new Image();
                         
                img.onload = function () {
                    if (this.width < 250) {
                        //self.html += "<div class=\"image-upload item-image\" style=\"background-image:url(" + img.src + ")\"></div>";
                        console.log("hailx" +img.src);
                        src.push(img.src);
                    }
                };      
                img.src = URL.createObjectURL(files[i]);         
            }
            console.log(src);
            if (html != "") {
                $(".box-images").append(self.html);
            }
            
        });

       
    });

})(jQuery);