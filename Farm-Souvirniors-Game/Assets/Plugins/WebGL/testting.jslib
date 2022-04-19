mergeInto(LibraryManager.library, {
  GameOver: function (action) {
    window.dispatchReactUnityEvent(
      "GameOver",
      Pointer_stringify(action)
    );
    
  },
});