$(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        let cats = window.cats;

        let source = await $.get("/catTemplate.html");
        let templ = Handlebars.compile(source);

        let context = {
            cats
        };

        let html = templ(context);

        $("#allCats").html(html);
    }

})

function showInfo(id) {
    $(`#${id}`).toggle();
}