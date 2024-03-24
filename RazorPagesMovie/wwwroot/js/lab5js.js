function toplamGoster() {
    // İki sayıyı al
    var sayi1 = document.getElementById('sayi1').value;
    var sayi2 = document.getElementById('sayi2').value;
    
    // Sayıları topla
    var toplam = parseInt(sayi1) + parseInt(sayi2);
    
    // Toplamı mavi kutucuk içinde göster
    var kutu = document.getElementById('toplamKutu');
    kutu.textContent = 'Sum of the ' + sayi1 + ' and ' + sayi2 +' is: ' + toplam;
    kutu.style.display = 'block';
  }
