let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();

let months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
let monthAndYear = document.getElementById("monthAndYear");
showCalendar(currentMonth, currentYear);

//DODATO
function count(){
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

function deleteOpt(){
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

function clearMonth(){
    //da bi se vratio na Month u listi meseca prilikom klikne na sledeci mesec, da ne bi ostao prethodno stisnuti
    var selekt1 = document.getElementById('mesec');
    selekt1.value="Month";
}

function clearYear(){
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

function showCal(){
    //poziva se kad se klikne na dugme Show calendar, popunjava liste Day i Month
    count();
    countMonth();
    countYear();
    var check = document.getElementById('checkForma');
    check.checked=false;
    document.getElementById('dan').disabled=true;
    document.getElementById('mesec').disabled=true;
    document.getElementById('godina').disabled=true;
}

function hideCal(){
    //poziva se kad se klikne na dugme Hide calendar, prazni liste Day i Month
    deleteOpt();
    $('#mesec').empty();
    $('#godina').empty();
}

//KRAJ DODATOG

function next() {
    currentYear = (currentMonth === 11) ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    showCalendar(currentMonth, currentYear);
    //dodato
    $.getScript("js/kalendar.js"); //ponovo ucitava skriptu pri svakom kliku na dugme
    deleteOpt();
    count();
    clearMonth();
    clearYear();
}

function previous() {
    currentYear = (currentMonth === 0) ? currentYear - 1 : currentYear;
    currentMonth = (currentMonth === 0) ? 11 : currentMonth - 1;
    showCalendar(currentMonth, currentYear);
    //dodato
    $.getScript("js/kalendar.js");
    deleteOpt();
    count();
    clearMonth();
    clearYear();
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
                //cell.className="dugme-u-kalendaru1";
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
                    //cell.classList.add("bg-danger");
                } // color today's date
                cell.appendChild(cellText);
                row.appendChild(cell);
                date++;
            }


        }

        tbl.appendChild(row); // appending each row into calendar body.
    }

}