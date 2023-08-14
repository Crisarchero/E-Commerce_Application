function setReviewValue() {


var ratingSubmission = document.getElementById("ratingSubmission")
var ratingValue = document.getElementById("ratingValue")

ratingValue.innerHTML = ratingSubmission.value;

ratingSubmission.addEventListener("change", (event) => {
    ratingValue.innerHTML = event.target.value;
})
}