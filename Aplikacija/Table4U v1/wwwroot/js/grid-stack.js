
    var grid = GridStack.init({
			
     disableOneColumnMode: true,
     float: true,
    alwaysShowResizeHandle: /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent),
	  resizable: {
        handles: ' se, sw'
      },
	  removable: '#trash',
      removeTimeout: 100,
      acceptWidgets: '.newWidget',
      



    });
    
    grid.on('added', function addTableUserInfo(e, items) { 

      let newTable=document.querySelector(".grid-stack").querySelector(".newWidget");

      if(newTable==null)
      return;
      
      let x=newTable.getAttribute("data-gs-x");
      let y=newTable.getAttribute("data-gs-y");
      let width=newTable.getAttribute("data-gs-width");
      let height=newTable.getAttribute("data-gs-height");
      grid.removeWidget(newTable);
      let label= prompt("Enter table's label\n(Required *, Max. 7 symbols)");
      if(label==null)
      return;
      while(label==""||label.length>7||label.includes("`")||label.includes("~"))
      {
        if(label.includes("`")||label.includes("~"))
        label= prompt("Enter table's label\n Invalid input! \"`\" and \"~\" are not allowed. \n(Required *,Max. 7 symbols)");
        else
      label= prompt("Enter table's label\n Invalid input! \n(Required *,Max. 7 symbols)");
      if(label==null)
      return;
      }
      let capacity=prompt("Enter "+label+"'s capacity\n(Required *)");
      
      if(capacity==null)
      return;
     
      while(capacity==""||isNaN(capacity)||capacity>99999||capacity<1)
      {
        capacity=prompt("Enter "+label+"'s capacity\nInvalid input! \n(Required *)");
        if(capacity==null)
        return;
      
       
      }
      
      let addedTable=grid.addWidget('<div><div class="grid-stack-item-content addedTable"><div class=\"table-label\">'+label+'</div><div class=\"table-capacity\">('+capacity+')</div></div></div>',{x:x,y:y,width:width,height:height});
  
   
     



	


	});
    
    grid.on('change', function tableResize(e, items) { 
     
      
      if(items[0].el.getAttribute("data-gs-width")=="1"||items[0].el.getAttribute("data-gs-height")=="1")
          {
             
            items[0].el.querySelector(".table-label").style.fontSize="16px";
            items[0].el.querySelector(".table-capacity").style.fontSize="13px";
          }
          else
          if((items[0].el.getAttribute("data-gs-width")=="2"||items[0].el.getAttribute("data-gs-width")=="3")&&items[0].el.getAttribute("data-gs-height")=="2")
          {
             
            items[0].el.querySelector(".table-label").style.fontSize="32px";
            items[0].el.querySelector(".table-capacity").style.fontSize="25px";
          }


     });
    function log(type, items) {
      var str = '';
      items.forEach(function(item) { str += ' (x,y)=' + item.x + ',' + item.y; });
      console.log(type + items.length + ' items.' + str );
    }
    
   
$('.newWidget').draggable({
      revert: 'invalid',
      scroll: true,
      appendTo: '.grid-stack',
      helper: 'clone'
    });
   