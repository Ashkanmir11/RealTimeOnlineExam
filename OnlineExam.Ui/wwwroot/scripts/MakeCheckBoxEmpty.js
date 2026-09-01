window.CheckExamInputDuplicate = function (qusetionId, totalChoices, selectedChoice) {
    for (i = 0; i < totalChoices; i++) {
        var object = document.getElementById(`${qusetionId}multipleChoiceAnswer${i}`);
        if (i + 1 === selectedChoice) {
            object.checked = true;
        }
        else {
            object.checked = false;
        }
    }
}
window.FillCheckBoxAfterLoad = function (qusetionId, selectedChoice) {
    var object = document.getElementById(`${qusetionId}multipleChoiceAnswer${selectedChoice}`);
    object.checked = true; 
}

