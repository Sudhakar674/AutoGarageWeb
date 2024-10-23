
/**--------------------------------Save Car Master Start--------------------------------**/
    function validate() {
        debugger;
        if ($("#Company").val() == "") {
            $("#Company").addClass('errormessage');
            $("#Company").focus();
            return false;
        }
        else if ($("#CarName").val() == "") {
            $("#CarName").addClass('errormessage');
            $("#CarName").focus;
            return false;
        }
        else if ($("#ModelNumber").val() == "") {
            $("#ModelNumber").addClass('errormessage');
            $("#ModelNumber").focus;
            return false;
        }
        else if ($("#EngeenType").val() == "") {
            $("#EngeenType").addClass('errormessage');
            $("#EngeenType").focus;
            return false;
        }

        var CarDetails = {
            Company:$("#Company").val(),
            CarName:$("#CarName").val(),
            ModelNumber:$("#ModelNumber").val(),
            EngeenType:$("#EngeenType").val()
        };   
        $.ajax({
            type: 'POST',
            url: '/Master/SaveCarMaster',
            data: JSON.stringify(CarDetails),
            /* contentType: "application/json; charset=utf-8",*/
            contentType: "application/json;",
            dataType: 'json',
            success: function (data) {
                if (data.Result == "yes") {
                    window.location.reload;
                }
                else {

                }
            }
        })
    
}
/**--------------------------------Save Car Master End--------------------------------**/



//function CarListMaster() {
//    debugger;
//    $.ajax({
//        type: "Get",
//        url: '/Master/CarList',
//        data: "{}",
//        dataType: "json",
//        success: function (result) {
//            $.each(result.CarMasterlst, function (i, v) {
//                debugger;
//                var tableLength = $("#tBodyId tr").length;
//                var SerialNo = tableLength;
//                var tr = "<tr>";
//                tr += "<td>" + SerialNo + "</td>";
//                tr += "<td style='Display:none'>" + v.Id + "</td>";
//                tr += "<td class='Company_" + v.Id + "'>" + v.Company + "</td>";
//                tr += "<td class='CarName_" + v.Id + "'>" + v.CarName + "</td>";
//                tr += "<td class='ModelNumber_" + v.Id + "'>" + v.ModelNumber + "</td>";
//                tr += "<td class='EngeenType_" + v.Id + "'>" + v.EngeenType + "</td>";
//                tr += "<td><a onclick='return EditCarMaster(" + v.Id + ")' class='btn btn-sm btn-success edit-item-btn'>Edit<i class='fa fa-edit'></i></a> <a onclick='return DeleteCarMaster(" + v.Id + ")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";
//                tr += "<td style='Display:none'></td>";
//                tr += "</tr>";
//                $("#tBodyId").append(tr);
//            });
//        }
//    });
//}