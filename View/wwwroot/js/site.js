// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/SignalRAdmin").build();

connection.on("LoadAdminDashboard", function () {
    location.href = '/Admin/Dashboard'
});

connection.start()
    .then(function () {
        console.log("SignalR connection established");
    })
    .catch(function (err) {
        console.error("Error establishing SignalR connection: ", err);
    });