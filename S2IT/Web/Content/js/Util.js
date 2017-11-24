$("input[type=tel]").mask("(99) 99999-9999");

function converterTimestampParaData(timestamp) {
    var currData = timestamp.replace("/Date(", "").replace(")/", "");
    var newDate = new Date();
    newDate.setTime(currData);
    var month = newDate.getMonth() + 1;
    var day = newDate.getDate();
    var hour = newDate.getHours();
    var min = newDate.getMinutes();
    var sec = newDate.getSeconds();
    month = (month < 10 ? "0" : "") + month;
    day = (day < 10 ? "0" : "") + day;
    hour = (hour < 10 ? "0" : "") + hour;
    min = (min < 10 ? "0" : "") + min;
    sec = (sec < 10 ? "0" : "") + sec;
    return day + "/" + month + "/" + newDate.getFullYear() + " às " + hour + ":" + min + ":" + sec;
}

function configurarBotoesDelete() {
    var deleteLinks = document.querySelectorAll(".delete");

    for (var i = 0; i < deleteLinks.length; i++) {
        deleteLinks[i].addEventListener("click", function (event) {
            event.preventDefault();

            var href = this.getAttribute("href");

            bootbox.confirm({
                message: this.getAttribute("data-confirm"),
                buttons: {
                    confirm: {
                        label: "Sim",
                        className: "btn-success"
                    },
                    cancel: {
                        label: "Não",
                        className: "btn-danger"
                    }
                },
                callback: function (result) {
                    if (result) {
                        $.get(href, function(data) {
                            if (data.Message === undefined) {
                                location.reload();
                            } else {
                                bootbox.alert(data.Message);
                            }
                        });
                    }
                }
            });
        });
    }
}