import 'https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js'

var myModal;
export function showModal(id)
{
    myModal = new bootstrap.Modal(document.getElementById(id));
    myModal.show();
}
export function hideModal()
{
    myModal.hide();
}