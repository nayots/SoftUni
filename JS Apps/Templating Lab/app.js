$(async () => {
    let contacts = await $.get("./data.json");

    let contactTemplateSource = await $.get("./templates/contact.html");
    let contactTemplate = Handlebars.compile(contactTemplateSource);

    let contactsHtml = contactTemplate({
        contacts
    });
    $("#list").html(contactsHtml);
    $("#list div.contact").click(async function () {
        let ele = $(this);
        let id = Number(ele.attr("data-id"));
        $(".contact").removeClass("active");
        ele.addClass("active");
        await showDetails(id);
    });

    async function showDetails(id) {
        let contact = contacts[id];

        let detailsTemplateSource = await $.get("./templates/details.html");
        let detailsTemplate = Handlebars.compile(detailsTemplateSource);

        let detailsHtml = detailsTemplate(contact);

        $("#details").html(detailsHtml);
    }
});