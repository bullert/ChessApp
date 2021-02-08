
function OnChessPieceGrab(e, element) {
    
    if (!$(element).is(".chess-board-field"))
        return;

    $(element).find(".chess-piece").addClass("dragged");
}

function OnChessPieceDrag(e, element) {

    let dragged = $(document).find(".chess-piece.dragged");

    if ($(dragged).length == 0)
        return;

    let square = $(dragged).closest(".chess-board-field");

    if ($(square).length == 0)
        return;

    let offset = $(square).offset();

    let x = e.clientX - offset.left - square.width() / 2,
        y = e.clientY - offset.top - square.height() / 2;

    $(dragged).css("transform", "translate(" + x + "px, " + y + "px)");
}

function OnChessPieceDrop(e, element) {

    $(document).find(".chess-piece.dragged")
        .css("transform", "translate(0px, 0px)")
        .removeClass("dragged");
}