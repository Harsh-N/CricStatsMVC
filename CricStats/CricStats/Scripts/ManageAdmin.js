

//$(document).ready(function () {
    //var dataArray = [];
    //var table = $('#dataTableManagePlayer').DataTable({
    //    data: dataArray,
    //    columns: [{ data: 'PlayerId' }, { data: 'playerName' }]

    //});
    //LoadPlayers(table);



    //function LoadPlayers(table) {
    //    alert("test Load")
    //    var urlstr = $('#dataTableManagePlayer').attr('data-url');
    //    $.ajax({
    //        type: "Get",
    //        async: true,
    //        url: urlstr,
    //        data: JSON.stringify({}),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (data) {
    //            dataArray = eval('(' + data.d + ')')
    //        },
    //        error: function () {
    //            alert("Players not found");
    //        },
    //        complete: function () {
    //            table.clear();
    //            table.rows.add(dataArray).draw();
    //        }
    //    })
    //}

//});