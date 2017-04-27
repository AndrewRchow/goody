var goody = {
    utilities: {}
    , layout: {
        preStart: null,
        postStart: null
    }
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}

};
goody.moduleOptions = {
    APPNAME: "goodyApp"
        , extraModuleDependencies: []
        , runners: []
        , page: goody.page//we need this object here for later use
};

goody.layout.startUp = function () {

    console.debug("goody.layout.startUp");
    if (goody.layout.preStart) {
        console.debug("goody.layout.preStart");
        goody.layout.preStart();
    }
    //this does a null check on sabio.page.startUp
    if (goody.page.startUp) {
        console.debug("goody.page.startUp");
        goody.page.startUp();
    }
    if (goody.layout.postStart) {
        console.debug("goody.layout.postStart");
        goody.layout.postStart();
    }
};
goody.APPNAME = "goodyApp";//legacy



$(document).ready(goody.layout.startUp);