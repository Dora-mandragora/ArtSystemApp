// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function chooseAccess(){
    let buttons = document.getElementsByName("accs-buttons");
    let chosen_button = document.getElementById("accs-button-choose");
    let count = buttons.length;
    for(let i = 0; i< count; i++){
        let activeButton = buttons[i];
        activeButton.addEventListener("click", onClick);
        function onClick(){
            activeButton.setAttribute("disabled", true);
            chosen_button.value = activeButton.id;
            for(let j = 0; j < count; j++){
                if(j != i) buttons[j].removeAttribute("disabled");
            }
        }
    }
}