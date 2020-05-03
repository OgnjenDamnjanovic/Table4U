let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();

let months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
let monthAndYear = document.getElementById("monthAndYear");
showCalendar(currentMonth, currentYear);

$('#mesec').change(function popuniDane(){
    var broj =0;
    var index = $("#mesec").get(0).selectedIndex;
    if(index==2){
        broj = 28;
    }
    else if(index==4 || index==6 || index==9 || index==11){
        broj = 30;
    }
    else if(index==0){
        broj=0;
    }
    else{
        broj=31;
    }
    $('#dan').empty();
    var selekt = document.getElementById('dan');
    var opcija1 = document.createElement("option");
    opcija1.appendChild( document.createTextNode("Day") );
    opcija1.value="Day";
    selekt.appendChild(opcija1);
    if(broj!=0)
    {
        for(var i=1;i<=broj;i++)
        {
            var opcija = document.createElement("option");
            opcija.appendChild( document.createTextNode(i) );
            opcija.value = i; 
            selekt.appendChild(opcija);
        }
    }
});

function countDay(){
    //pravi selekt listu sa brojem dana u mesecu
    var numItems = $('.dugme-u-kalendaru').length;
    var selekt = document.getElementById('dan');
    var i=0;
    var opcija1 = document.createElement("option");
    opcija1.appendChild( document.createTextNode("Day") );
    opcija1.value="Day";
    selekt.appendChild(opcija1);
    for(i=1;i<=numItems;i++)
    {
        var opcija = document.createElement("option");
        opcija.appendChild( document.createTextNode(i) );
        opcija.value = i; 
        selekt.appendChild(opcija);
    }
}

function clearDay(){
    //prazni selekt listu
    $('#dan').empty();
}

function countMonth(){
    //pravi selekt listu sa mesecima
    var selekt = document.getElementById('mesec');
    var i=0;
    var opcija1 = document.createElement("option");
    opcija1.appendChild( document.createTextNode("Month") );
    opcija1.value="Month";
    selekt.appendChild(opcija1);
    for(i=0;i<months.length;i++)
    {
        var opcija = document.createElement("option");
        opcija.appendChild( document.createTextNode(months[i]) );
        opcija.value = months[i]; 
        selekt.appendChild(opcija);
    }
}

function showTitleMonth(){
    //da bi se vratio na Month u listi meseca prilikom klikne na sledeci mesec, da ne bi ostao prethodno stisnuti
    var selekt1 = document.getElementById('mesec');
    selekt1.value="Month";
}

function showTitleYear(){
    var selekt1 = document.getElementById('godina');
    selekt1.value="Year";
}

function countYear(){
    var selekt = document.getElementById('godina');
    var opcija1 = document.createElement("option");
    opcija1.appendChild( document.createTextNode("Year") );
    opcija1.value="Year";
    selekt.appendChild(opcija1);
    for(i=0;i<3;i++)
    {
        var opcija = document.createElement("option");
        opcija.appendChild( document.createTextNode(currentYear+i));
        opcija.value = currentYear+i; 
        selekt.appendChild(opcija);
    }
}

function nabavi(){
    document.getElementById('proba').value="";
    var mesecText = document.getElementById('monthAndYear');
    var niz = mesecText.innerHTML.split(" ");
    var mesec = niz[0];
    var d = new Date();
    var lokalId = document.getElementById('idIn').value;
    var nadji = months.indexOf(mesec);
    if(nadji!=-1)
    {
        if(nadji >= d.getMonth() || parseInt(niz[1])>d.getFullYear())
        {
            $.ajax({
                type: "GET",
                url: '/Object?Id='+lokalId+'&handler=Nabavi',
                beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: {id:lokalId, date:mesec},
                success: function (response) {
                    document.getElementById('proba').value=response;
                    obojiDogadjaje();
                }
            })
        }
    }
}

function obojiDogadjaje(){
    var podaci = document.getElementById('proba').value;
    var niz = podaci.split("|");
    if(podaci!="|,|,|,|")
    {
      var nizDatumi = niz[0].split(",");
      for(var i=0;i<(nizDatumi.length)-1;i++)
      {
        var polje = document.getElementById(parseInt(nizDatumi[i]));
        polje.style.backgroundColor='#5BBD50';
      }
    }
}

function ocisti()
{
    $('#brMesta').prop('selectedIndex',0);
    $('#slobodniTermini').prop('selectedIndex',0);
}

$('#checkForma').click(function checkSelect(){
  var dan = document.getElementById('dan');
  var mesec = document.getElementById('mesec');
  var godina = document.getElementById('godina');
  ocisti();
  if (this.checked == false){
      dan.disabled=true;
      mesec.disabled=true;
      godina.disabled=true;
      dan.value="Day";
      mesec.value="Month";
      godina.value="Year";
      obojiDogadjaje();
    } else {
      dan.disabled=false;
      mesec.disabled=false;
      godina.disabled=false;
      $(".dugme-u-kalendaru").each(function() {
          this.style.backgroundColor = '#fff';
        });
      obojiDogadjaje();
      dan.value="Day";
      mesec.value="Month";
      godina.value="Year";
    }
});

function showCal(){
    //poziva se kad se klikne na dugme Show calendar, popunjava liste Day i Month
    countDay();
    countMonth();
    countYear();
    var check = document.getElementById('checkForma');
    check.checked=false;
    document.getElementById('dan').disabled=true;
    document.getElementById('mesec').disabled=true;
    document.getElementById('godina').disabled=true;
    nabavi();
    ocisti();
}

function hideCal(){
    //poziva se kad se klikne na dugme Hide calendar, prazni liste Day i Month
    clearDay();
    $('#mesec').empty();
    $('#godina').empty();
    ocisti();
}

function next() {
    currentYear = (currentMonth === 11) ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    showCalendar(currentMonth, currentYear);
    $.getScript("js/kalendar.js"); //ponovo ucitava skriptu pri svakom kliku na dugme
    clearDay();
    countDay();
    showTitleMonth();
    showTitleYear();
    nabavi();
    $('#brMesta').prop('selectedIndex',0);
    $('#slobodniTermini').prop('selectedIndex',0);
}

function previous() {
    currentYear = (currentMonth === 0) ? currentYear - 1 : currentYear;
    currentMonth = (currentMonth === 0) ? 11 : currentMonth - 1;
    showCalendar(currentMonth, currentYear);
    $.getScript("js/kalendar.js");
    clearDay();
    countDay();
    showTitleMonth();
    showTitleYear();
    nabavi();
    $('#brMesta').prop('selectedIndex',0);
    $('#slobodniTermini').prop('selectedIndex',0);
}

function showCalendar(month, year) {
    //Pre svega se pribave svi dogadjaji iz baze, ako je dogadjaj.month==month smesta se u novi niz DogadjajiMeseca, zatim se dogadjaji iz tog niza prikazuju u kalendar
    

    let firstDay = (new Date(year, month)).getDay();
    let daysInMonth = 32 - new Date(year, month, 32).getDate();

    let tbl = document.getElementById("calendar-body"); // body of the calendar

    // clearing all previous cells
    tbl.innerHTML = "";

    // filing data about month and in the page via DOM.
    monthAndYear.innerHTML = months[month] + " " + year;

    

    // creating all cells
    let date = 1;
    for (let i = 0; i < 6; i++) {
        // creates a table row
        let row = document.createElement("tr");

        //creating individual cells, filing them up with data.
        for (let j = 0; j < 7; j++) {
            if (i === 0 && j < firstDay) {
                let cell = document.createElement("td");
                let cellText = document.createTextNode("");
                cell.appendChild(cellText);
                row.appendChild(cell);
            }
            else if (date > daysInMonth) {
                break;
            }

            else {
                let cell = document.createElement("td");
                cell.id=date;
                cell.className="dugme-u-kalendaru";
                let cellText = document.createTextNode(date);
                if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
                    cell.style.color="red";
                }
                cell.appendChild(cellText);
                row.appendChild(cell);
                date++;
            }


        }

        tbl.appendChild(row); // appending each row into calendar body.
    }

}