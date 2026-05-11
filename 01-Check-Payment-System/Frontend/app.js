const apiUrl = "http://localhost:5097/api/CheckPayment";

async function loadData() {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) throw new Error("Failed to load the datas!");

        const datas = await response.json();

        let html = "";

        datas.forEach(check => {
            html += `
                <tr>
                    <td>${check.name}</td>
                    <td>${check.paid}</td>
                    <td>${check.date}</td>
                    <td>${check.paymentType}</td>
                    <td>${check.isProcessed ? "Igen" : "Nem" || "undefined"}</td>
                    <td><button onclick="del(${check.id})">Törlés</td>
                </tr>
            
            `;
        });

        document.getElementById("tableBody").innerHTML = html;

        console.log(datas);
    } catch (error) {
        console.error("Error: ", error)
    }
}

document.getElementById("addForm").onsubmit = async function (event) {
    event.preventDefault();

    const newCheck = {
        Name: document.getElementById("name").value,
        Paid: parseInt(document.getElementById("paid").value),
        Date: document.getElementById("date").value,
        PaymentType: parseInt(document.getElementById("paymentType").value),
        IsProcessed: document.getElementById("isProcessed").checked
    };

    try {
        console.log("Backendnek küldöm: ", JSON.stringify(newCheck));

        const response = await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newCheck)
        });

        if (!response.ok) throw new Error("Failed to add the item!");

        loadData();
        document.getElementById("addForm").reset();
    } catch (error) {
        console.log("Error: ", error);
    }
}

async function del(id) {
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) throw new Error("Failed to delete this item!");

        loadData();

    } catch (error) {
        console.log("Error: ", error)
    }
}

loadData();