/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.allowedContent = true;
    config.image_previewText = " ";
    config.toolbar =
    [
        { name: 'insert', groups: ['insert', 'links', 'colors', 'styles'], items: ['Image', 'Smiley', 'Link', 'Unlink', 'TextColor', 'BGColor'] },
        { name: 'paragraph', groups: ['align', 'bidi'], items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike'/*, 'Subscript', 'Superscript'*/] }
    ];
};
