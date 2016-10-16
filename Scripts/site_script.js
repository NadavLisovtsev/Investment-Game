
function getData(key) {

    return $(".DataDiv").find("." + key).html();
}

function checkInvestmentInput(input, money) 
{
    error = null;
    if (isNaN(Number(input))) {
        error = 'Please enter only numbers'
    }
    if (Number(input) < 0) {
        error = 'You cannot enter a negative amount of money.'
    }
    if (Number(input) > Number(money)) {
        error = 'You cannot invest more money than you have.'
    }
    return error

}

$(function () {

    $('.FakeInvestButton').click(function (e) {
        e.preventDefault();
        $('.WrongInput').hide();
        error = checkInvestmentInput($('.MoneyInput').val(), getData("MoneyData"))
        if (error != null) {
            $('.WrongInput').html(error).show();

            return;
        }

        $('.WaitGif').show();
        $('.RoundData').hide();
        setTimeout(function () {
            $('.WaitGif').hide();
            $('.InvestButton').trigger('click');
            $('.RoundData').show();

        }, Number(getData("WaitTime")));
    });
});