function validateEmails(email) {
    let pattern = /^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]+$/g;
    console.log(pattern.test(email) ? "Valid" : "Invalid")
}

// validateEmails("valid@email.bg")