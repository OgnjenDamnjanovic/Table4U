let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();

let months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

let monthAndYear = document.getElementById("monthAndYear");
showCalendar(currentMonth, currentYear);

function count(){
    //pravi selekt listu sa brojem dana u mesecu
    var numItems = $('.dugme-u-kalendaru').length;
    var b = document.querySelector(".brojDana");
    b.innerHTML=numItems;
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

function next() {
    currentYear = (currentMonth === 11) ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    showCalendar(currentMonth, currentYear);
    $.getScript("js/kalendar.js");
    deleteOpt();
    count();
    //$.getScript("js/highlight.js");
}

function previous() {
    currentYear = (currentMonth === 0) ? currentYear - 1 : currentYear;
    currentMonth = (currentMonth === 0) ? 11 : currentMonth - 1;
    showCalendar(currentMonth, currentYear);
    $.getScript("js/kalendar.js");
    deleteOpt();
    count();
    //$.getScript("js/highlight.js");
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
    var a = document.querySelector(".datumMesec");
    a.innerHTML = months[month] + " " + year;
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