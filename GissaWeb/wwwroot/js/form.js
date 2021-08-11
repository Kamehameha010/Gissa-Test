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

window.addEventListener("load", (e) => {
    const email = document.querySelector("#email"), pwd = document.querySelector("#password"),
        tel = document.querySelector("input[name=phoneNumber]");
    email.setAttribute("pattern", "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
    pwd.setAttribute("pattern", `^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{6}$`);
    tel.setAttribute("pattern", `^\\d{8}$`);
});

document.forms[0].addEventListener("submit", (e) => {

    e.preventDefault();
    let options = document.querySelector("#softSkill");
    if (options.selectedOptions.length < 3) {
        options.setCustomValidity("Debe eligir minimo 3")

        return false;
    }

    let objRequest = new Request(`/Register/Create`, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(getData())
    });

    fetch(objRequest).then(r => r.text);
});



function getData() {
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
