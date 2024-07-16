///JsTree Click Event
$('#workGrouptree').on("changed.jstree", function (e, data) {

    
    $('[class="modal-title badge bg-info"]').html(data.instance.get_node(data.selected).text);//Get Text = Environment Name
    $('[class="modal-title badge bg-warning"]').html(data.instance.get_node(data.selected).text);//Get Text = Environment Name



    //Get Parent ID For Add Modal
    $('#addmodal [name="ParentID"]').val(data.selected);

    $('#updatemodal [name="WorkGroupID"]').val(data.selected);
    $('#updatemodal [name="WorkGroupTitle"]').val(data.instance.get_node(data.selected).text);

    //Get Selected ID + All Childs ID For Delete Modal
    if (data.node != null) {
        $('#deletemodal [name="WorkGroupID"]').val(data.selected + ',' + data.node.children_d);//get all Child Nodes For Delete
    } else {
        $('#deletemodal [name="WorkGroupID"]').val(data.selected);//get all Child Nodes For Delete
    }



    //$("#crudcontroll").show('slow');
});

///JsTree Context Menu
$.jstree.defaults.contextmenu = {
    select_node: true,
    items: function (o, cb) { // Could be an object directly
        return {
            "create": {
                "separator_before": false,
                "separator_after": true,
                "icon": "../Content/images/create.png",
                "_disabled": false, //(this.check("create_node", data.reference, {}, "last")),
                "label": "ایجاد",
                "action": function (data) {
//                    addFrm(o.id);
                    $('[data-bs-target="#addmodal"]').click();

                }
            },
            "rename": {
                "separator_before": false,
                "separator_after": false,
                "_disabled": false, //(this.check("rename_node", data.reference, this.get_parent(data.reference), "")),
                "label": "ویرایش",

                //"shortcut": 113,
                //"shortcut_label": 'F2',
                "icon": "../Content/images/update.png",
                "action": function (data) {
                    //updateFrm(o.id);
                    $('[data-bs-target="#updatemodal"]').click();
                }
            },
            "remove": {
                "separator_before": false,
                "icon": "../Content/images/trash.png",
                "separator_after": false,
                "_disabled": false, //(this.check("delete_node", data.reference, this.get_parent(data.reference), "")),
                "label": "حذف",
                "action": function (data) {
                    $('[data-bs-target="#deletemodal"]').click();
                }
            },
            //"ccp": {
            //    "separator_before": true,
            //    "icon": false,
            //    "separator_after": false,
            //    "label": "ویرایش",
            //    "action": false,
            //    "submenu": {
            //        "cut": {
            //            "separator_before": false,
            //            "separator_after": false,
            //            "label": "Cut",
            //            "action": function (data) {
            //                var inst = $.jstree.reference(data.reference),
            //                    obj = inst.get_node(data.reference);
            //                if (inst.is_selected(obj)) {
            //                    inst.cut(inst.get_selected());
            //                }
            //                else {
            //                    inst.cut(obj);
            //                }
            //                $("[name='oldrootid']").val(obj.id);//Get Old ID For Cut
            //                $('[name="cutandcopybutton"]').attr('data-target', '.bs-Cut-modal-sm');
            //            }
            //        },
            //        "copy": {
            //            "separator_before": false,
            //            "icon": false,
            //            "separator_after": false,
            //            "label": "Copy",
            //            "action": function (data) {
            //                var inst = $.jstree.reference(data.reference),
            //                    obj = inst.get_node(data.reference);
            //                if (inst.is_selected(obj)) {
            //                    inst.copy(inst.get_selected());
            //                }
            //                else {
            //                    inst.copy(obj);
            //                }
            //                $("[name='oldrootid']").val(obj.id);//Get Old ID For Copy
            //                $('[name="cutandcopybutton"]').attr('data-target', '.bs-Copy-modal-sm');

            //            }
            //        },
            //        "paste": {
            //            "separator_before": false,
            //            "icon": false,
            //            "_disabled": function (data) {
            //                return !$.jstree.reference(data.reference).can_paste();
            //            },
            //            "separator_after": false,
            //            "label": "Paste",
            //            "action": function (data) {
            //                var inst = $.jstree.reference(data.reference),
            //                    obj = inst.get_node(data.reference);
            //                $("[name='newrootid']").val(obj.id);//Get New ID For Paste
            //                $('[name="cutandcopybutton"]').click();
            //            }
            //        }
            //    }
            //}
            /*,
                "closeAll": {
                    "separator_before": true,
                    "icon": false,
                    "_disabled": false,
                    "separator_after": false,
                    "label": "بستن همه",
                    "action": function () {
                        $('#PhysicalPlaceTree').jstree().close_all();
                    }
                }*/
        };
    }
};

///JsTree Search
var to = false;
$('#JstreeSearch').keyup(function () {
    if ($('#JstreeSearch').val().length > 1 || $('#JstreeSearch').val().length < 1) {
        if (to) { clearTimeout(to); }
        to = setTimeout(function () {
            var v = $('#JstreeSearch').val();
            $('#workGrouptree').jstree(true).search(v);
        }, 250);
    }
});

//function JsondateConverter(value) {
//    if (value != null) {
//        var d = new Date(parseInt(value.substr(6)));
//        //alert(d.toLocaleDateString('fa-IR'));
//        return d.toLocaleDateString('fa-IR', { year: 'numeric', month: '2-digit', day: '2-digit' });
//    }
//}