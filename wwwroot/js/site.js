// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



async function CallInference() {
    // format the responses to account for dummies

    if (document.getElementById("eastweste").value == 0) {
        document.getElementById("eastwestw").value = 1
    }

    else {
        document.getElementById("eastwestw").value = 0
    }

    if (document.getElementById("adultsubadult").value == 0) {
        document.getElementById("childsubchild").value = 1
    }
    else {
        document.getElementById("childsubchild").value = 0;
    }

    if (document.getElementById("preservation").value == 1) {
        document.getElementById("well").value = 0
        document.getElementById("fair").value = 0
        document.getElementById("poorly").value = 0
        document.getElementById("badly").value = 0
        document.getElementById("skeleton").value = 0
        document.getElementById("deteriorated").value = 0
    }

    else if (document.getElementById("preservation").value == 2) {
        document.getElementById("preservation").value = 0
        document.getElementById("well").value = 1
        document.getElementById("fair").value = 0
        document.getElementById("poorly").value = 0
        document.getElementById("badly").value = 0
        document.getElementById("skeleton").value = 0
        document.getElementById("deteriorated").value = 0
    }

    else if (document.getElementById("preservation").value == 3) {
        document.getElementById("preservation").value = 0
        document.getElementById("well").value = 0
        document.getElementById("fair").value = 1
        document.getElementById("poorly").value = 0
        document.getElementById("badly").value = 0
        document.getElementById("skeleton").value = 0
        document.getElementById("deteriorated").value = 0
    }

    else if (document.getElementById("preservation").value == 4) {
        document.getElementById("preservation").value = 0
        document.getElementById("well").value = 0
        document.getElementById("fair").value = 0
        document.getElementById("poorly").value = 1
        document.getElementById("badly").value = 0
        document.getElementById("skeleton").value = 0
        document.getElementById("deteriorated").value = 0
    }

    else if (document.getElementById("preservation").value == 5) {
        document.getElementById("preservation").value = 0
        document.getElementById("well").value = 0
        document.getElementById("fair").value = 0
        document.getElementById("poorly").value = 0
        document.getElementById("badly").value = 1
        document.getElementById("skeleton").value = 0
        document.getElementById("deteriorated").value = 0
    }

    else if (document.getElementById("preservation").value == 6) {
        document.getElementById("preservation").value = 0
        document.getElementById("well").value = 0
        document.getElementById("fair").value = 0
        document.getElementById("poorly").value = 0
        document.getElementById("badly").value = 0
        document.getElementById("skeleton").value = 1
        document.getElementById("deteriorated").value = 0
    }

    else {
        document.getElementById("preservation").value = 0
        document.getElementById("well").value = 0
        document.getElementById("fair").value = 0
        document.getElementById("poorly").value = 0
        document.getElementById("badly").value = 0
        document.getElementById("skeleton").value = 0
        document.getElementById("deteriorated").value = 1
    }

    if (document.getElementById("wrapping").value == 1) {
        document.getElementById("partial").value = 0
        document.getElementById("bones").value = 0
    }

    else if (document.getElementById("wrapping").value == 2) {
        document.getElementById("wrapping").value = 0
        document.getElementById("partial").value = 1
        document.getElementById("bones").value = 0
    }

    else {
        document.getElementById("wrapping").value = 0
        document.getElementById("partial").value = 0
        document.getElementById("bones").value = 1
    }

    if (document.getElementById("haircolor").value == 1) {
        document.getElementById("black").value = 0
        document.getElementById("brownred").value = 0
        document.getElementById("red").value = 0
        document.getElementById("blond").value = 0
    }

    else if (document.getElementById("haircolor").value == 2) {
        document.getElementById("haircolor").value = 0
        document.getElementById("black").value = 1
        document.getElementById("brownred").value = 0
        document.getElementById("red").value = 0
        document.getElementById("blond").value = 0
    }

    else if (document.getElementById("haircolor").value == 3) {
        document.getElementById("haircolor").value = 0
        document.getElementById("black").value = 0
        document.getElementById("brownred").value = 1
        document.getElementById("red").value = 0
        document.getElementById("blond").value = 0
    }

    else if (document.getElementById("haircolor").value == 4) {
        document.getElementById("haircolor").value = 0
        document.getElementById("black").value = 0
        document.getElementById("brownred").value = 0
        document.getElementById("red").value = 1
        document.getElementById("blond").value = 0
    }

    else {
        document.getElementById("haircolor").value = 0
        document.getElementById("black").value = 0
        document.getElementById("brownred").value = 0
        document.getElementById("red").value = 0
        document.getElementById("blond").value = 1
    }

    if (document.getElementById("area").value == 1) {
        document.getElementById("nnw").value = 0
        document.getElementById("nw").value = 0
        document.getElementById("se").value = 0
        document.getElementById("sw").value = 0
    }

    else if (document.getElementById("area").value == 2) {
        document.getElementById("area").value = 0
        document.getElementById("nnw").value = 0
        document.getElementById("nw").value = 1
        document.getElementById("se").value = 0
        document.getElementById("sw").value = 0
    }

    else if (document.getElementById("area").value == 2) {
        document.getElementById("area").value = 0
        document.getElementById("nnw").value = 0
        document.getElementById("nw").value = 0
        document.getElementById("se").value = 1
        document.getElementById("sw").value = 0
    }

    else {
        document.getElementById("area").value = 0
        document.getElementById("nnw").value = 0
        document.getElementById("nw").value = 0
        document.getElementById("se").value = 0
        document.getElementById("sw").value = 1
    }

    if (document.getElementById("ageatdeath").value == 1) {
        document.getElementById("child").value = 0
        document.getElementById("infant").value = 0
        document.getElementById("newborn").value = 0
    }

    else if (document.getElementById("ageatdeath").value == 2) {
        document.getElementById("ageatdeath").value = 0
        document.getElementById("child").value = 1
        document.getElementById("infant").value = 0
        document.getElementById("newborn").value = 0
    }

    else if (document.getElementById("ageatdeath").value == 3) {
        document.getElementById("ageatdeath").value = 0
        document.getElementById("child").value = 0
        document.getElementById("infant").value = 1
        document.getElementById("newborn").value = 0
    }

    else {
        document.getElementById("ageatdeath").value = 0
        document.getElementById("child").value = 0
        document.getElementById("infant").value = 0
        document.getElementById("newborn").value = 1
    }
    // format the form data into json so the model in the API can understand it
    var json = {
        squarenorthsouth: parseFloat(document.getElementById("squarenorthsouth").value),
        depth: parseFloat(document.getElementById("depth").value),
        southtohead: parseFloat(document.getElementById("southtohead").value),
        squareeastwest: parseFloat(document.getElementById("squareeastwest").value),
        westtohead: parseFloat(document.getElementById("westtohead").value),
        westtofeet: parseFloat(document.getElementById("westtofeet").value),
        southtofeet: parseFloat(document.getElementById("southtofeet").value),
        northsouth_N: parseFloat(document.getElementById("northsouth").value),
        eastwest_E: parseFloat(document.getElementById("eastweste").value),
        eastwest_W: parseFloat(document.getElementById("eastwestw").value),
        adultsubadult_A: parseFloat(document.getElementById("adultsubadults").value),
        adultsubadult_C: parseFloat(document.getElementById("childsubchild").value),
        preservation_badlypreserved: parseFloat(document.getElementById("badly").value),
        preservation_deteriorated: parseFloat(document.getElementById("deteriorated").value),
        preservation_fair: parseFloat(document.getElementById("fair").value),
        preservation_poorlypreserved: parseFloat(document.getElementById("poorly").value),
        preservation_skeleton: parseFloat(document.getElementById("skeleton").value),
        preservation_wellpreserved: parseFloat(document.getElementById("well").value),
        preservation_wrapped: parseFloat(document.getElementById("preservation").value),
        wrapping_B: parseFloat(document.getElementById("bones").value),
        wrapping_H: parseFloat(document.getElementById("partial").value),
        wrapping_W: parseFloat(document.getElementById("wrapping").value),
        haircolor_A: parseFloat(document.getElementById("brownred").value),
        haircolor_B: parseFloat(document.getElementById("haircolor").value),
        haircolor_D: parseFloat(document.getElementById("blond").value),
        haircolor_K: parseFloat(document.getElementById("black").value),
        haircolor_R: parseFloat(document.getElementById("red").value),
        area_NE: parseFloat(document.getElementById("area").value),
        area_NNW: parseFloat(document.getElementById("nnw").value),
        area_NW: parseFloat(document.getElementById("nw").value),
        area_SE: parseFloat(document.getElementById("se").value),
        area_SW: parseFloat(document.getElementById("sw").value),
        ageatdeath_A: parseFloat(document.getElementById("ageatdeath").value),
        ageatdeath_C: parseFloat(document.getElementById("child").value),
        ageatdeath_I: parseFloat(document.getElementById("infant").value),
        ageaatdeath_N: parseFloat(document.getElementById("newborn").value)
    }

    // serialize the newly created JSON object
    var jsonString = JSON.stringify(json);

    try {
    // send the POST request to the URL that houses our API
    const response = await fetch("https://localhost:44360/predict", {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json'
                },
        body: jsonString
    })

    // convert the response content as a string
    var responseString = await response.text();

    // do something with the response
    alert(responseString);

        } catch (error) {
        // handle the exception
        console.error(error);
        }
}

document.getElementById("predictionBtn").addEventListener("click", CallInference())
