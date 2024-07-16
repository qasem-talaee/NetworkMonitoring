////function showPleaseWait() {
////    $('body').plainOverlay(
////        'show',
////        {
////            fillColor: 'white',
////            opacity: 0.8,
////            progress: function () {
////                return $('<div class="font-sahel-fd" style="color:black"><h1><span style="color:blue">لطفا صبر کنید</span></h1></div>');
////            }
////        }
////    );
////};
function showPleaseWait() {
    $('body').plainOverlay(
        'show',
        {
            fillColor: 'rgb(10, 35, 36)',
            opacity: 0.8,
            progress: function () {
                return $(`
<div class="example-item-wrap k-d-flex k-align-items-center k-justify-content-center">
    <div id="loader-large" style="color:blue"></div>
</div>
<script>
var largeLoader = $('#loader-large').kendoLoader({
        size: 'large',
        type:'converging-spinner',
        themeColor:'warning',
    }).data("kendoLoader");
</script>
`);
            }
        }
    );
};
function hidePleaseWait() {
    $('body').plainOverlay('hide');
}


