
export default class APImanager {


    static getAllReports = () => {
        return fetch("https://localhost:5000/api/reports", {
            "method": "GET",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(a => a.json())
    }
}

