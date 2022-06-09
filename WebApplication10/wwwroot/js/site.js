// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const alertSuccess = (message, timeoutAfter) => 
    createAlert(message, 'success', timeoutAfter);

const alertError = (message, timeoutAfter) =>
    createAlert(message, 'error', timeoutAfter);


const createAlert = (message, type, timeoutAfter) => {
    const alert = document.createElement('div')
    const container = document.createElement('div')
    container.classList.add('aalert--container');
    alert.classList.add('aalert')
    container.innerHTML = message;
    
    if (type === 'success') {
        alert.classList.add('aalert--success')
    } 
    else if (type === 'warning') {
        alert.classList.add('aalert--warning')
    } 
    else if (type === 'error') {
        alert.classList.add('aalert--error')
    }
    
    alert.appendChild(container);
    document.body.appendChild(alert);
    setTimeout(() => {
        alert.remove();
    }, timeoutAfter);
}