_default:
    @just -l

build-doc:
	docfx --debug docfx.json

serve-doc:
	docfx serve generated/docs

