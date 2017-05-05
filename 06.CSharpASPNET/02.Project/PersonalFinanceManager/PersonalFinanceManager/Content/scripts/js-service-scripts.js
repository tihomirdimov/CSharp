function ClearCategoryForm() {
    $('#category-name').val('');
    $('#category-id').val('');
}

function ClearBookForm() {
    $('#book-name').val('');
    $('#book-currency').val('');
    $('#book-id').val('');
}

function ClearMoneyStreamForm() {
    $('#moneyStream-name').val('');
    $('#moneyStream-amount').val('');
    $('#moneyStream-date').val('');
    $('#moneyStream-isIncome').removeAttr('checked');
    $('#moneyStream-id').val('');
}