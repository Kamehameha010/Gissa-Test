import { HttpRequest } from "./request.js";


const body = document.body;

body.addEventListener("click", (e) => {
    let target = e.target
    let { id } = target;
    switch (id) {
        case "addPhone": {
            const parent = document.querySelector(".phone-container .form-group");
            let input = document.createElement("input");
            input.type = "tel";
            input.name = "phoneNumber"
            input.classList.add("form-control")
            input.setAttribute("pattern", "\\d{8}")
            parent.appendChild(input);
        }

    }
})

body.addEventListener("input", (e) => {

    let target = e.target;
    switch (target.name) {
        case "phoneNumber": {
            /* if (!/^\d{8}$/.test(target.value)) {
                target.setCustomValidity("Campo debe tener 8 digitos");
                return false;
            } */
            return;
        }
        case "cardId": {
            let select = document.querySelector("#typeId");

            /* if (select.value == "1") {
                console.log(target.value.length != 9);
                if (target.value.length != 9) {
                    target.setCustomValidity("Campo debe tener 9 digitos");
                    return false;
                }
            } */
            return;
        }
        case "email": {
            /*  if (!/^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/.test(target.value)) {
                 target.setCustomValidity("Correo invalido");
                 return false;
             } */
            return;
        }

    }
});

document.forms[0].addEventListener("submit",(e) => {

    e.preventDefault();
    let options = document.querySelector("#softSkill");
    /* if (options.selectedOptions.length < 3) {
        options.setCustomValidity("Debe eligir minimo 3")
        
        return false;
    } */

    let objRequest = new Request(`/Register/Create`, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(await getData())
    });

    fetch(objRequest).then(r=> r.text);
});


"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6}$"


async function getData() {
    let form = Object.fromEntries(new FormData(document.forms[0]));
    let { userId, fullName, cardId, username, password, rol, typeId } = form;
    let tels = document.querySelectorAll("input[name=phoneNumber]");
    let phones = [];
    for (let tel of tels) {
        phones.push({ userId: 0, phoneId: 0, phoneNumber: tel.value })
    }
    let skills = document.querySelector("#softSkill")
    let userSkills = [];
    for (let skill of skills.selectedOptions) {
        userSkills.push({ userId: 0, UserSkillId: 0, softSkillId: skill.value })
    }

    return { userId, fullName, cardId, username, password, rol, typeId, phones, userSkills }

}