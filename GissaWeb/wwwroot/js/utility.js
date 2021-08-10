export const createAlert = (parent, message, state) => {
    const div = document.querySelector(`${parent}`);
    div.className = `alert alert-${state} mt-4 alert-dismissible`
    div.setAttribute("role", "alert")
    const button = document.createElement("button");
    button.type = "button";
    button.className = "close";
    button.setAttribute("data-dismiss", "alert");
    button.setAttribute("aria-hidden", "true");
    button.textContent = "x";
    const h6 = document.createElement("h6");
    h6.textContent = message;
    div.appendChild(button);
    div.appendChild(h6);
}