function solve() {
   let searchButton = document.querySelector("#searchBtn");
   searchButton.addEventListener("click", handler);
   function handler(e){
      Array.from(document.querySelectorAll(".select")).map(x => x.remove());
      let allRows = document.querySelectorAll("body > table > tbody>tr");
      let inputField = document.querySelector("#searchField").value.toLowerCase();
 
      for (const element of allRows) {
         let elementChildren = element.children;
         for (const child of elementChildren) {
            let currCellValue = (child.textContent).toLowerCase();
            if (inputField !='' && currCellValue.includes(inputField)) {
               element.className = 'select';
            }
         }
      }
      document.querySelector("#searchField").value = '';
   };
}