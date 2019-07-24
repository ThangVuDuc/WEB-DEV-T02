$(document).ready(function () {
    var ref = new Ref();
});

class Ref extends Base {
    constructor() {
        super();
        this.InitEventsRef();
    }

    InitEventsRef() {
        $('.main-table tbody').on('click', 'tr .uncheck', this.TickRow);
        $('.toolbar').on('click', 'button.delete', this.ClickButtonDelete.bind(this));
        $('.main-table tbody').on('click', 'tr', this.RowOnClick);
    }

    /**
     * Thực hiện chức năng xóa 1 bản ghi dữ liệu
     * Người tạo: VDThang
     * Ngày tạo: 19/07/2019
     * */

    ClickButtonDelete() {
        var me = this;
        var listRefID = [];
        var listRow = $('.select,.tick[recordID]');
        $.each(listRow, function (index, item) {
            var refid = item.getAttribute('recordID');
            listRefID.push(refid);
        });
        $.ajax({
            method: 'DELETE',
            url: '/refs',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(listRefID),
            success: function (res) { 
                me.loadData();
                me.SetStatusButton();
            },
            error: function (res) {
                alert("Không xóa được, dịch vụ đang bị lỗi. Liên hệ với MISA để làm việc");
            }
        });
    }

    /**
     * Thực hiện chức năng khi tích chọn 1 hàng
     * Người tạo: VDThang
     * Ngày tạo: 24/07/2019
     * */
    TickRow() {
        $(this).parent().addClass('tick');
    }

    /**
     * Thực hiện chức năng khi chọn 1 hàng
     * Người tạo: VDThang
     * Ngày tạo: 19/07/2019
     * */
    RowOnClick() {
        $('button').removeAttr('disabled');
        $('tr').removeClass('select');
        $(this).addClass('select');
    }

    //loadData() {
    //    super.loadData();
    //}

}

