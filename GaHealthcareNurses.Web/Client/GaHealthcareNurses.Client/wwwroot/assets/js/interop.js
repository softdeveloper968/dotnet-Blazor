window.removeHeaderCheckBox = function () {
    var grid = document.getElementById('Grid');
    var headerCells = grid.querySelectorAll('.e-headercell');
    var count = 1
    for (var i = 0; i < headerCells.length; i++) {
        if (headerCells[i].querySelector('.e-checkbox-wrapper')) {
            var span = this.document.createElement('span');
            span.classList.add('e-headertext')
            span.innerText = 'Select'/* + count*/;
            count++;
            headerCells[i].querySelector('.e-headercelldiv').appendChild(span);
            headerCells[i].querySelector('.e-checkbox-wrapper').remove();
        }
    }
}