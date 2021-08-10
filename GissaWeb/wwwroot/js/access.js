
import { HttpRequest } from "./request.js";
import { createAlert } from "./utility.js";

const form = document.forms[0];

form.addEventListener("submit", async (e) => {
    e.preventDefault();

    let objRequest = new Request(`${location.href}Access/Login`, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(Object.fromEntries(new FormData(form)))
    })

    let result = await HttpRequest.SendASync(objRequest);
    console.log(result);
    if (result.data) {
        let {rol} = result.data;
        switch (parseInt(rol)) {
            case "1":
                location.assign(location.href+"Register/Index")
                return;
            case "2":
                location.assign(location.href+"Home/Index")
                return;
        }
    } else {
        createAlert("#alert", "Verifique sus credenciales", "danger");
    }
})