var MainDate;
$(function () {
    getRobot();
});

function getRobot() {
    var url = urlRobot;

    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#rotacaoCabeca').text(data.head.headRotationStateDescription);
            $('#inclinacaoCabeca').text(data.head.headInclinationStateDescription);
            $('#cotoveloEsquerdo').text(data.leftArm.ancon.description);
            $('#cotoveloDireito').text(data.rightArm.ancon.description);
            $('#punhoEsquerdo').text(data.leftArm.fist.description);
            $('#punhoDireito').text(data.rightArm.fist.description);
            MainDate = data;

        }
    });
}

function changeInclination(action) {
    var url = urlRobot + "/moveHead";

    MainDate.head.ActionInclination = action;

    $.ajax({
        type: "PUT",
        url: url,
        data: JSON.stringify(MainDate),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#rotacaoCabeca').text(data.head.headRotationStateDescription);
            $('#inclinacaoCabeca').text(data.head.headInclinationStateDescription);
            $('#cotoveloEsquerdo').text(data.leftArm.ancon.description);
            $('#cotoveloDireito').text(data.rightArm.ancon.description);
            $('#punhoEsquerdo').text(data.leftArm.fist.description);
            $('#punhoDireito').text(data.rightArm.fist.description);
            MainDate = data;
            MainDate.head.ActionInclination = 0;
        },
        error: function (jqXHR, exception) {
            MainDate.head.ActionInclination = 0;
            alert(jqXHR.responseText);
        }
    });
}

function changeRotation(action) {
    var url = urlRobot + "/moveHead";

    MainDate.head.ActionRotation = action;

    $.ajax({
        type: "PUT",
        url: url,
        data: JSON.stringify(MainDate),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#rotacaoCabeca').text(data.head.headRotationStateDescription);
            $('#inclinacaoCabeca').text(data.head.headInclinationStateDescription);
            $('#cotoveloEsquerdo').text(data.leftArm.ancon.description);
            $('#cotoveloDireito').text(data.rightArm.ancon.description);
            $('#punhoEsquerdo').text(data.leftArm.fist.description);
            $('#punhoDireito').text(data.rightArm.fist.description);
            MainDate = data;
            MainDate.head.ActionRotation = 0;
        },
        error: function (jqXHR, exception) {
            MainDate.head.ActionRotation = 0;
            alert(jqXHR.responseText);
        }
    });
}

function changeAncon(side, action) {
    var url = urlRobot + "/moveAncon";

    if (side === 2) {
        MainDate.leftArm.action = side;
        MainDate.leftArm.ancon.action = action;
    }
    else {
        MainDate.rightArm.action = side;
        MainDate.rightArm.ancon.action = action;
    }

    
    $.ajax({
        type: "PUT",
        url: url,
        data: JSON.stringify(MainDate),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#rotacaoCabeca').text(data.head.headRotationStateDescription);
            $('#inclinacaoCabeca').text(data.head.headInclinationStateDescription);
            $('#cotoveloEsquerdo').text(data.leftArm.ancon.description);
            $('#cotoveloDireito').text(data.rightArm.ancon.description);
            $('#punhoEsquerdo').text(data.leftArm.fist.description);
            $('#punhoDireito').text(data.rightArm.fist.description);
            MainDate = data;
            MainDate.leftArm.action = 0;
            MainDate.rightArm.action = 0;
            MainDate.leftArm.ancon.action = 0;
            MainDate.rightArm.ancon.action = 0;
        },
        error: function (jqXHR, exception) {
            MainDate.leftArm.action = 0;
            MainDate.rightArm.action = 0;
            MainDate.leftArm.ancon.action = 0;
            MainDate.rightArm.ancon.action = 0;
            alert(jqXHR.responseText);
        }
    });
}

function changeFist(side, action) {
    var url = urlRobot + "/moveFist";

    if (side === 2) {
        MainDate.leftArm.action = side;
        MainDate.leftArm.fist.action = action;
    }
    else {
        MainDate.rightArm.action = side;
        MainDate.rightArm.fist.action = action;
    }


    $.ajax({
        type: "PUT",
        url: url,
        data: JSON.stringify(MainDate),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#rotacaoCabeca').text(data.head.headRotationStateDescription);
            $('#inclinacaoCabeca').text(data.head.headInclinationStateDescription);
            $('#cotoveloEsquerdo').text(data.leftArm.ancon.description);
            $('#cotoveloDireito').text(data.rightArm.ancon.description);
            $('#punhoEsquerdo').text(data.leftArm.fist.description);
            $('#punhoDireito').text(data.rightArm.fist.description);
            MainDate = data;
            MainDate.leftArm.action = 0;
            MainDate.rightArm.action = 0;
            MainDate.leftArm.fist.action = 0;
            MainDate.rightArm.fist.action = 0;
        },
        error: function (jqXHR, exception) {
            MainDate.leftArm.action = 0;
            MainDate.rightArm.action = 0;
            MainDate.leftArm.fist.action = 0;
            MainDate.rightArm.fist.action = 0;
            alert(jqXHR.responseText);
        }
    });
}