
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

    static getOneReport = (id) => {
        return fetch(`https://localhost:5000/api/reports/${id}`, {
            "method": "GET",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(res => res.json())
    }

    static putReport = (id, body) => {
        return fetch(`https://localhost:5000/api/reports/${id}`, {
            "method": "PUT",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
            "body": JSON.stringify(
                body
            )
        })
            .then(res => res.json())
    }

    static getReportExpneses = (id) => {
        return fetch(`https://localhost:5000/api/expneses/${id}`, {
            "method": "GET",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(res => res.json())
    }

    static postExpense = (body) => {
        // console.log("blah")
        return fetch("https://localhost:5000/api/expenses", {
            "method": "POST",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`, "Accept": "application/json"
            },
            "body": JSON.stringify(
                body
            )
        })
            .then(res => {
                console.log("response in post", res)
                return res.json();
            }).catch(error => {
                console.log(error)
            })
    }

    static deleteExpense = (id) => {
        return fetch(`https://localhost:5000/api/expneses/${id}`, {
            "method": "DELETE",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(res => res.json())
    }

    static getExpenseTypes = () => {
        return fetch('https://localhost:5000/api/expenseTypes', {
            "method": "GET",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
        })
            .then(res => {
                console.log("response in api manager", res)
                return res.json();
            })
    }
}

