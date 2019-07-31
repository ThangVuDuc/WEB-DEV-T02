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
        $('.main-table tbody').on('click', 'tr', {"jsObject": this}, this.RowOnClick);
        $('.toolbar').on('click', 'button.add-new', this.OpenDialogAdd);
        $('#dialog').on('click', 'button.save', this.AddNewRef.bind(this));
    }

    /**
     * Hàm thực hiện thêm mới phiếu thu
     * Người tạo: VDThang
     * Ngày tạo: 26/07/2019
     * */
    AddNewRef() {
        var me = this;
        var listInput = $('#dialog [property]');
        var object = {};
        $.each(listInput, function (index, item) {
            var propertyName = item.getAttribute('property');
            var value = $(this).val();
            object[propertyName] = value;
        });
        $.ajax({
            method: 'POST',
            url: '/refs',
            data: JSON.stringify(object),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                if (res.Success) {
                    $('#dialog').dialog('close');
                    me.loadData();
                } else {
                    alert(res.Message);
                }
            }
        })
    }

    /**
     * Hàm thực hiện mở dialog thêm mới phiếu thu, chi
     * Người tạo: VDThang
     * Ngày tạo: 26/07/2019
     * */
    OpenDialogAdd() {
        $("#dialog").dialog({
            modal: true,
            height: 300,
            width: 600
        });
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

    RowOnClick(event) {
        var me = event.data["jsObject"];
        $('button').removeAttr('disabled');
        $('tr').removeClass('select');
        $(this).addClass('select');
        me.LoadDetailTable();
    }

    /**
     * Hàm thực hiện load dữ liệu xuống bảng detail
     * Người tạo: VDThang
     * Ngày tạo: 31/07/2019
     * */
    LoadDetailTable() {
        var me = this;
        var refid = me.GetRowID();
        $.ajax({
            method: 'GET',
            url: '/refdetails/' + refid,
            success: function (res) {
                if (res.Success) {
                    debugger
                } else {
                    alert(res.Message);
                }
            }
        })
    }

    /**
     * Hàm thực hiện lấy id của hàng 
     * Người tạo: VDThang
     * Ngày tạo: 31/07/2019
     * */

    GetRowID() {
        var rowid = $('.select,.tick').data('recordID');
        return rowid;
    }

    //loadData() {
    //    super.loadData();
    //}

}

