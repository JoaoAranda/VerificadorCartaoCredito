function formataInteiro(campo, evt) {
    xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    campo.value = filtraNumeros(filtraCampo(campo));
    MovimentaCursor(campo, xPos);
}

function filtraCampo(campo) {
    var s = "";
    var cp = "";
    vr = campo.value;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) != "/"
                  && vr.substring(i, i + 1) != "-"
                  && vr.substring(i, i + 1) != "."
                  && vr.substring(i, i + 1) != "("
                  && vr.substring(i, i + 1) != ")"
                  && vr.substring(i, i + 1) != ":"
                  && vr.substring(i, i + 1) != ",") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
}

function filtraNumeros(campo) {
    var s = "";
    var cp = "";
    vr = campo;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) == "0" ||
                  vr.substring(i, i + 1) == "1" ||
                  vr.substring(i, i + 1) == "2" ||
                  vr.substring(i, i + 1) == "3" ||
                  vr.substring(i, i + 1) == "4" ||
                  vr.substring(i, i + 1) == "5" ||
                  vr.substring(i, i + 1) == "6" ||
                  vr.substring(i, i + 1) == "7" ||
                  vr.substring(i, i + 1) == "8" ||
                  vr.substring(i, i + 1) == "9") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
}

function MovimentaCursor(textarea, pos) {
    if (pos <= 0)
        return;
    if (typeof (document.selection) != 'undefined') {
        var oRange = textarea.createTextRange();
        var LENGTH = 1;
        var STARTINDEX = pos;
        oRange.moveStart("character", -textarea.value.length);
        oRange.moveEnd("character", -textarea.value.length);
        oRange.moveStart("character", pos);
        oRange.select();
        textarea.focus();
    }
    if (typeof (textarea.selectionStart) != 'undefined') {
        textarea.selectionStart = pos;
        textarea.selectionEnd = pos;
    }
}

function PosicaoCursor(textarea) {
    var pos = 0;
    if (typeof (document.selection) != 'undefined') {
        var range = document.selection.createRange();
        var i = 0;
        for (i = textarea.value.length; i > 0; i--) {
            if (range.moveStart('character', 1) == 0)
                break;
        }
        pos = i;
    }
    if (typeof (textarea.selectionStart) != 'undefined') {
        pos = textarea.selectionStart;
    }
    if (pos == textarea.value.length)
        return 0;
    else
        return pos;
}

function getEvent(evt) {
    if (!evt) evt = window.event;
    return evt;
}

function getKeyCode(evt) {
    var code;
    if (typeof (evt.keyCode) == 'number')
        code = evt.keyCode;
    else if (typeof (evt.which) == 'number')
        code = evt.which;
    else if (typeof (evt.charCode) == 'number')
        code = evt.charCode;
    else
        return 0;
    return code;
}

function teclaValida(tecla) {
    if (tecla == 8
           || tecla == 9 
           || tecla == 27 
           || tecla == 16 
           || tecla == 45 
           || tecla == 46 
           || tecla == 35 
           || tecla == 36 
           || tecla == 37 
           || tecla == 38 
           || tecla == 39 
           || tecla == 40)
        return false;
    else
        return true;
}