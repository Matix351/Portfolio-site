(() => {
    const dialog = document.getElementById('image-preview');
    const image = document.getElementById('image-preview-image');
    let trigger;
    let previousOverflow;

    // Delegation also handles project content rendered after Blazor navigation.
    document.addEventListener('click', event => {
        const link = event.target.closest('a[data-image-preview]');
        if (!link) return;
        event.preventDefault();
        trigger = link;
        image.src = link.href;
        image.alt = link.querySelector('img')?.alt || 'Project screenshot';
        previousOverflow = document.body.style.overflow;
        document.body.style.overflow = 'hidden';
        dialog.showModal();
    });

    // Includes the image, close button, and the modal's backdrop.
    dialog.addEventListener('click', () => dialog.close());
    dialog.addEventListener('close', () => {
        document.body.style.overflow = previousOverflow;
        image.removeAttribute('src');
        if (trigger?.isConnected) trigger.focus({ preventScroll: true });
        trigger = null;
    });
})();
