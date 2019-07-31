class Base {
    constructor() {
        this.loadData();
        this.InitEventsBase();
        this.SetStatusButton();
    }

    InitEventsBase() {

    }

    //contentType: "application/json; charset=utf-8",
    getData() {
        var fakeData = [];
        $.ajax({
            method: 'GET',
            url: '/refs',
            async: false,
            dataType: "json",
            success: function (res) {
                if (res.Success) {
                    fakeData = res.Data;
                } else {
                    alert(res.Message);
                }
            }
        });
        return fakeData;
    }

    loadData() {
        var data = this.getData();
        var fields = $('.main-table th[fieldName]');
        $('.main-table tbody').empty();
        $.each(data, function (index, item) {
            var rowHTML = $('<tr></tr>').data("recordID",item["RefID"]);
            $.each(fields, function (fieldIndex, fieldItem) {
                var fieldName = fieldItem.getAttribute('fieldName');
                var value = item[fieldName];
                var cls = 'text-left';
                if (fieldName === "RefDate") {
                    value = new Date(value);
                }
                var type = $.type(value);
                switch (type) {
                    case "date": value = value.formatddMMyyyy();
                        cls = 'text-center';
                        break;
                    case "number": value = value.formatMoney();
                        cls = 'text-right';
                        break;
                }
                if (fieldName) {
                    rowHTML.append('<td class = "{1}">{0}</td>'.format(value, cls));
                } else {
                    rowHTML.append('<td class ="uncheck"></td>');
                }
            });
            $('.main-table tbody').append(rowHTML);
        });
    }

    SetStatusButton() {
        var sizeTable = $('.main-table tbody tr').length;
        if (sizeTable === 0) {
            $('button.delete').attr('disabled', 'disabled');
        }
    }
}