$('td').on('click', function(e) {
    var tgt = e.target;
    e.stopImmediatePropagation();
    $('td').each(function(idx, cell) {
      cell.style.backgroundColor = '#fff';
    });
    tgt.style.backgroundColor = '#0093e0';
  });