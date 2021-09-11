import '/_content/ACUI.Shared/jquery/jquery-3.6.0.min.js';

export function val(element, val) {
    if (val == undefined) {
        return $(element).val();
    } else {
        return $(element).val(val);
    }
}

export function valById(id, val) {
    if (val == undefined) {
        return $('#' + id).val();
    } else {
        return $('#' + id).val(val);
    }
}

export function click(element, val) {
    if (val == undefined) {
        return $(element).click();
    } else {
        return $(element).click(val);
    }
}

export function clickById(id, val) {
    if (val == undefined) {
        return $('#' + id).click();
    } else {
        return $('#' + id).click(val);
    }
}