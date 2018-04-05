function attachEvents() {
    $("#btnLoadTowns").click(async () => {
        let towns = $("#towns").val().split(",").filter(t => t !== "").map(t => {
            let obj = {
                town: t
            }
            return obj;
        });
        if (towns) {
            let source = await $.get("./template.html");
            let templ = Handlebars.compile(source);
            let context = {
                towns
            }

            let html = templ(context);

            $("#root").html(html);
            $("#towns").val("");
        }
    })
}