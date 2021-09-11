function ToDateTimeString(ticks) {
    let date = new Date(ticks);
    return date.toLocaleDateString() + ' ' + date.toLocaleTimeString();
}