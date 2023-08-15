document.addEventListener("DOMContentLoaded", function () {
    // Add event listeners to form submit buttons
    const signupForm = document.querySelector(".signup form");
    const loginForm = document.querySelector(".login form");

    signupForm.addEventListener("submit", function (event) {
        if (!validateSignupForm()) {
            event.preventDefault();
        }
    });

    loginForm.addEventListener("submit", function (event) {
        if (!validateLoginForm()) {
            event.preventDefault();
        }
    });

    function validateSignupForm() {
        const mailInput = document.getElementById("mainInput");
        const nameInput = document.getElementById("nameInput");
        const passInput = document.getElementById("passInput");
        const repassInput = document.getElementById("repassInput");
        const signError = document.getElementById("signError");

        signError.textContent = "";

        if (mailInput.value.trim() === "") {
            signError.textContent = "Email is required.";
            return false;
        }

        if (nameInput.value.trim() === "") {
            signError.textContent = "Name is required.";
            return false;
        }

        if (passInput.value.trim() === "") {
            signError.textContent = "Password is required.";
            return false;
        }

        if (repassInput.value.trim() === "") {
            signError.textContent = "Re-enter password is required.";
            return false;
        }

        if (passInput.value !== repassInput.value) {
            signError.textContent = "Passwords do not match.";
            return false;
        }

        return true;
    }

    function validateLoginForm() {
        const mailin = document.getElementById("mailin");
        const passin = document.getElementById("passin");
        const logError = document.getElementById("logError");

        logError.textContent = "";

        if (mailin.value.trim() === "") {
            logError.textContent = "Email is required.";
            return false;
        }

        if (passin.value.trim() === "") {
            logError.textContent = "Password is required.";
            return false;
        }

        return true;
    }
});
