const MIN_PLAYERS = $("#NumPlayers").data("val-range-min");
const MAX_PLAYERS = $("#NumPlayers").data("val-range-max");

$("#NumPlayers").change(function (eventData) {
    var numPlayers = Number($(eventData.currentTarget).val());
    if (numPlayers < MIN_PLAYERS || numPlayers > MAX_PLAYERS) {
        return;
    }
    $(".player").css("display", "none");
    for (var playerNum = 1; playerNum != numPlayers + 1; playerNum++) {
        $("#Player-" + playerNum).css("display", "block");
    }
});

const INITIAL_PLAYER_OPTIONS = $("#Player-1 option");
const DUMMY_OPTION_LABEL = $("#Player-1 option")[0].label;

$(".player-selector").change(function (eventData) {
    var selectedOption = $(eventData.currentTarget).find("option:selected").first();
    debugger;
    $(".player").empty();
    $(".player").append($(INITIAL_PLAYER_OPTIONS).clone());
    if (selectedOption[0].label == DUMMY_OPTION_LABEL) {
        console.log("Dummy selected.");
        return;
    }
});