function attachEvents() {
    const baseUrl = "https://baas.kinvey.com/appdata/kid_Sy3cFMu9G/biggestCatches";
    const auth = `Basic ${btoa("guest:123")}`;
    $($("button.load")[0]).click(listAllCatches);
    $($("button.add")[0]).click(addCatch);

    async function listAllCatches() {
        let catchesEle = $("#catches");
        catchesEle.empty();
        let catches = await $.ajax({
            method: "GET",
            url: baseUrl,
            headers: {
                "Authorization": auth
            }
        });
        for (const c of catches) {
            let catchEle = createCatchEle(c);
            catchesEle.append(catchEle);
        }

    }

    function addCatch(params) {
        let addForm = $("#addForm");
        let [angler, weight, species, location, bait, captureTime] = $("#addForm input");

        let body = {
            angler: $(angler).val(),
            weight: Number($(weight).val()),
            species: $(species).val(),
            location: $(location).val(),
            bait: $(bait).val(),
            captureTime: Number($(captureTime).val())
        };

        $.ajax({
            method: "POST",
            url: baseUrl,
            headers: {
                "Authorization": auth,
                "Content-type": "application/json"
            },
            data: JSON.stringify(body)
        }).then((res) => {
            let newCatch = createCatchEle(res);
            $("#catches").append(newCatch);
        })

    }

    function createCatchEle(c) {
        let result = $(`<div class="catch" data-id="${c._id}">`);

        let anglerInput = $(`<input type="text" class="angler" value="${c.angler}" />`);
        result.append(`<label>Angler</label>`)
        result.append(anglerInput);

        let weightInput = $(`<input type="number" class="weight" value="${c.weight}" />`);
        result.append(`<label>Weight</label>`);
        result.append(weightInput);

        let speciesInput = $(`<input type="text" class="species" value="${c.species}" />`);
        result.append(`<label>Species</label>`);
        result.append(speciesInput);

        let locationInput = $(`<input type="text" class="location" value="${c.location}" />`);
        result.append(`<label>Location</label>`);
        result.append(locationInput);

        let baitInput = $(`<input type="text" class="bait" value="${c.bait}" />`);
        result.append(`<label>Bait</label>`);
        result.append(baitInput);

        let captureTimeInput = $(`<input type="number" class="captureTime" value="${c.captureTime}" />`);
        result.append(`<label>Capture Time</label>`);
        result.append(captureTimeInput);

        let updateBtn = $(`<button class="update">Update</button>`).click(() => {
            let id = result.attr("data-id");
            let angler = anglerInput.val();
            let weight = Number(weightInput.val());
            let species = speciesInput.val();
            let location = locationInput.val();
            let bait = baitInput.val();
            let captureTime = Number(captureTimeInput.val());

            let body = {
                angler,
                weight,
                species,
                location,
                bait,
                captureTime
            };
            $.ajax({
                method: "PUT",
                url: baseUrl + `/${id}`,
                headers: {
                    "Authorization": auth,
                    "Content-type": "application/json"
                },
                data: JSON.stringify(body)
            });
        });
        let deletebtn = $(`<button class="delete">Delete</button>`).click(() => {
            let id = result.attr("data-id");

            $.ajax({
                method: "DELETE",
                url: baseUrl + `/${id}`,
                headers: {
                    "Authorization": auth,
                    "Content-type": "application/json"
                }
            }).then((r) => {
                result.remove();
            });
        })

        result.append(updateBtn);
        result.append(deletebtn);

        return result;
    }
}