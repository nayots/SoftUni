function attachEvents() {
    const url = "https://phonebook-nakov.firebaseio.com/phonebook";

    $("#btnLoad").click(loadList);
    $("#btnCreate").click(createContact);

    function loadList() {
        let list = $("#phonebook");
        list.empty();
        $.ajax({
            method: "GET",
            url: url + ".json"
        }).then((res) => {
            for (const key in res) {
                let contact = {};
                contact.key = key;
                contact.value = res[key];
                let li = createLi(contact);
                list.append(li);
            }
        }).catch((err) => console.log(err));
    }

    function createContact() {
        let list = $("#phonebook");
        let personNameEle = $("#person")
        let personPhoneEle = $("#phone")
        let personName = personNameEle.val();
        let personPhone = personPhoneEle.val();
        personNameEle.val("");
        personPhoneEle.val("");
        let data = {
            person: personName,
            phone: personPhone
        }
        $.ajax({
            method: "POST",
            url: url + ".json",
            data: JSON.stringify(data)
        }).then((res) => {
            let contact = {};
            contact.key = res.name;
            contact.value = {
                person: personName,
                phone: personPhone
            };
            let li = createLi(contact);
            list.append(li);
        }).catch((err) => console.log(err));
    }

    function createLi(contact) {
        let li = $(`<li>${contact.value.person}: ${contact.value.phone} </li>`)
            .append($("<button>[Delete]</button>").click(() => {
                $.ajax({
                    method: "DELETE",
                    url: `${url}/${contact.key}.json`
                }).then((res) => {
                    li.remove();
                }).catch((err) => console.log(err));
            }));
        return li;
    }

    // loadList();
}