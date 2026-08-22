window.examPageMonitor = function () {
    return document.hidden;
};
window.PreventCopyAndPaste = function () {

    let property = document.getElementsByTagName('textarea');
    for (i = 0; i < property.length; i++) {
        property[i].addEventListener("copy", (e) => {
            e.preventDefault();
        });
        property[i].addEventListener("paste", (e) => {
            e.preventDefault();
            alert("امکان کپی و پیست در این آزمون وجود ندارد.");
        })
    }

};

